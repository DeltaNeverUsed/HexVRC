using UdonSharp;
using UnityEngine;
using VRC.SDKBase;


// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class WandPlayerFollower : UdonSharpBehaviour {

        public float maxDistance = 1.1f;

        private Rigidbody _rb;
        private VRCPlayerApi _player;

        private bool _movingTowardsPlayer;
        private void Start() {
            _rb = GetComponent<Rigidbody>();
            _player = Networking.LocalPlayer;
            if (Networking.IsOwner(gameObject))
                SendCustomEventDelayedFrames(nameof(Loop), 1);
        }

        public void Loop() {
            Vector3 playerPos = _player.GetBonePosition(HumanBodyBones.Chest);
            float height = _player.GetAvatarEyeHeightAsMeters();

            if (!_movingTowardsPlayer)
                _movingTowardsPlayer = Vector3.Distance(playerPos, transform.position) > height * maxDistance;
            else {
                _rb.velocity = Vector3.Lerp(_rb.velocity, playerPos - transform.position, 0.5f * Time.deltaTime);
                _movingTowardsPlayer = Vector3.Distance(playerPos, transform.position) > height;
            }
            
            SendCustomEventDelayedFrames(nameof(Loop), 1);
        }
    }
}