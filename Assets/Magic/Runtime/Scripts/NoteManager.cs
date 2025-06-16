using System;
using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.UdonNetworkCalling;
using VRC.Udon.Common.Interfaces;

#if !UDONSHARP_COMPILER && UNITY_EDITOR
using UnityEditor;
using UdonSharpEditor;
#endif

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
#if !UDONSHARP_COMPILER && UNITY_EDITOR
    [CustomEditor(typeof(NoteManager))]
    public class NoteManagerInspector : Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            NoteManager data = target as NoteManager;
            if (GUILayout.Button("Regenerate")) {
                int nbChildren = data.transform.childCount;
                for (int i = nbChildren - 1; i >= 0; i--)
                    DestroyImmediate(data.transform.GetChild(i).gameObject);

                data.notes = new Note[data.count];
                for (int i = 0; i < data.count; i++) {
                    GameObject instance = Instantiate(data.notePrefab, Vector3.zero, Quaternion.identity, data.transform);
                    instance.name = data.notePrefab.name + $"_{{{i}}}";
                    data.notes[i] = instance.GetComponent<Note>();
                    instance.SetActive(false);
                }
                
                UdonSharpEditorUtility.CopyProxyToUdon(data);
                EditorUtility.SetDirty(data);
            }
        }
    }
#endif

    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class NoteManager : UdonSharpBehaviour {
        public GameObject notePrefab;
        public int count = 40;

        public Note[] notes;
        public bool[] available;

        public void Start() {
            available = new bool[notes.Length];
            for (int i = 0; i < notes.Length; i++)
                available[i] = true;
        }

        [NetworkCallable]
        public void PlayNote(Vector3 position, int pitch, int clipIndex) {
            int freeIndex = Array.IndexOf(available, true);
            if (freeIndex == -1)
                return;
            
            Note note =  notes[freeIndex];
            note.gameObject.SetActive(true);
            available[freeIndex] = false;
            
            note.Play(position, Mathf.Clamp(pitch - 12, -12, 12), clipIndex);
        }

        public void Return(Note note) {
            int noteIndex = Array.IndexOf(notes, note);
            if (noteIndex == -1) {
                this.LogError("Note returned to NoteManager wasn't in NoteManager originally?");
                return;
            }
            
            note.gameObject.SetActive(false);
            available[noteIndex] = true;
        }
    }
}