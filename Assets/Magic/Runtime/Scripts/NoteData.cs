
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class NoteData {
        public readonly Vector3 Position;
        public readonly short Pitch;
        public readonly byte ClipIndex;
        public readonly long TickToPlay;
        
        public NoteData(Vector3 position, short pitch, byte clipIndex, long tickToPlay) {
            Position = position;
            Pitch = pitch;
            ClipIndex = clipIndex;
            TickToPlay = tickToPlay;
        }
    }
}