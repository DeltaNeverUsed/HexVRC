using UdonSharp;
using VRC.SDKBase;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class WandStackDisplayHandler : UdonSharpBehaviour {
        public void Start() => Drop();

        public void Pickup() {
            gameObject.SetActive(true);

            Vector3 headPosition = Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position;

            Vector3 toTarget = headPosition - transform.position;

            // Convert direction to local space
            Vector3 localDirection = transform.parent.InverseTransformDirection(toTarget);

            // Calculate the angle between local right (1, 0, 0) and the projected direction
            float angle = Mathf.Atan2(localDirection.x, localDirection.y) * Mathf.Rad2Deg;

            // Only rotate around local Z axis
            transform.localRotation = Quaternion.Euler(0, 0, -angle + 180);
        }

        public void Drop() {
            gameObject.SetActive(false);
        }
    }
}