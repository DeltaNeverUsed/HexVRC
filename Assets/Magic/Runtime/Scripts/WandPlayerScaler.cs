using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class WandPlayerScaler : UdonSharpBehaviour {
        private Vector3 _originalScale;

        private void Start() {
            _originalScale = transform.localScale / 1.2f;
        }

        public override void OnAvatarEyeHeightChanged(VRCPlayerApi player, float prevEyeHeightAsMeters) {
            if (!player.IsOwner(gameObject))
                return;

            transform.localScale = _originalScale * player.GetAvatarEyeHeightAsMeters();
        }
    }
}