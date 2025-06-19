using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [RequireComponent(typeof(AudioSource))]
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class Note : UdonSharpBehaviour {
        
        public AudioClip[] clips;
        
        private AudioSource _audio;
        private NoteManager _manager;
        
        public void Play(NoteData note) {
            if (!Utilities.IsValid(_audio)) {
                _audio = GetComponent<AudioSource>();
                _manager = GetComponentInParent<NoteManager>();
            }
            
            transform.position = note.Position;
            _audio.clip = clips[Mathf.Clamp(note.ClipIndex, 0, clips.Length-1)];
            _audio.pitch = Mathf.Pow(2, note.Pitch / 12f);
            _audio.Play();
            
            SendCustomEventDelayedSeconds(nameof(AudioFinished), _audio.clip.length + 0.1f);
        }

        public void AudioFinished() => _manager.Return(this);
    }
}