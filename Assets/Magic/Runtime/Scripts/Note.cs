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
        
        public void Play(Vector3 position, int pitch, int clipIndex) {
            if (!Utilities.IsValid(_audio)) {
                _audio = GetComponent<AudioSource>();
                _manager = GetComponentInParent<NoteManager>();
            }
            
            transform.position = position;
            clipIndex = Mathf.Clamp(clipIndex, 0, clips.Length);
            _audio.clip = clips[clipIndex];
            _audio.pitch = Mathf.Pow(2, pitch / 12f);
            _audio.Play();
            
            SendCustomEventDelayedSeconds(nameof(AudioFinished), _audio.clip.length + 0.1f);
        }

        public void AudioFinished() => _manager.Return(this);
    }
}