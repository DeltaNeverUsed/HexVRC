using System;
using System.Collections.Generic;
using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.UdonNetworkCalling;
using VRC.SDKBase;
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
        
        private readonly Queue<NoteData> _notesToPlay = new Queue<NoteData>();
        private readonly List<NoteData> _notesToSend = new List<NoteData>();
        private bool _playing = false;

        public void Start() {
            available = new bool[notes.Length];
            for (int i = 0; i < notes.Length; i++)
                available[i] = true;
            
            SendCustomEventDelayedSeconds(nameof(DispatchLoop), 1);
        }

        [NetworkCallable]
        public void PlayNotes(Vector3[] position, int[] pitch, int[] clipIndex, long[] tickToPlay) {
            int c = position.Length;
            long now = DateTime.UtcNow.Ticks;
            for (int i = 0; i < c; i++) {
                PlayNote(position[i], pitch[i], clipIndex[i], now + tickToPlay[i], false);
            }
        }
        
        public void PlayNote(Vector3 position, int pitch, int clipIndex, long tickToPlay, bool local = true) {
            NoteData data;
            pitch = Mathf.Clamp(pitch, -24, 24) - 12;
            if (local) {
                data = new NoteData(position, (short)pitch, (byte)clipIndex, tickToPlay);
                // ReSharper disable once PossibleInvalidCastException
                _notesToSend.Add(data);
            }
            else {
                data = new NoteData(position, (short)pitch, (byte)clipIndex, tickToPlay + TimeSpan.FromMilliseconds(1000).Ticks);
            }
            
            _notesToPlay.Enqueue(data);
            if (!_playing) {
                _playing = true;
                SendCustomEventDelayedFrames(nameof(PlayLoop), 1);
            }
        }
        
        public void DispatchLoop() {
            TimeSpan delay = TimeSpan.FromMilliseconds(1000);
            SendCustomEventDelayedSeconds(nameof(DispatchLoop), (float)delay.TotalSeconds);
            
            long ticks = DateTime.UtcNow.Ticks;
            
            int toSendCount = _notesToSend.Count;
            if (toSendCount < 1)
                return;
            
            Vector3[] positions = new Vector3[toSendCount];
            int[] pitches = new int[toSendCount];
            int[] clipIndexes = new int[toSendCount];
            long[] ticksToPlay = new long[toSendCount];

            for (int index = 0; index < toSendCount; index++) {
                NoteData note = _notesToSend[index];

                positions[index] = note.Position;
                pitches[index] = note.Pitch;
                clipIndexes[index] = note.ClipIndex;
                ticksToPlay[index] = delay.Ticks - (ticks - note.TickToPlay);
            }
            
            SendCustomNetworkEvent(NetworkEventTarget.Others, nameof(PlayNotes), positions, pitches, clipIndexes, ticksToPlay);
            _notesToSend.Clear();
        }

        public void PlayLoop() {
            if (_notesToPlay.Count < 1) {
                _playing = false;
                return;
            }

            while (_notesToPlay.Peek().TickToPlay <= DateTime.UtcNow.Ticks) {
                NoteData data = _notesToPlay.Dequeue();
                
                int freeIndex = Array.IndexOf(available, true);
                if (freeIndex == -1)
                    break;
            
                Note note =  notes[freeIndex];
                note.gameObject.SetActive(true);
                available[freeIndex] = false;
                
                note.Play(data);

                if (_notesToPlay.Count < 1)
                    break;
            }
            
            SendCustomEventDelayedFrames(nameof(PlayLoop), 1);
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