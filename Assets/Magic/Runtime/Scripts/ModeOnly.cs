using UdonSharp;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public enum Mode {
        VR,
        Desktop
    }

    public class ModeOnly : UdonSharpBehaviour {
        public Mode mode = Mode.VR;

        private void Start() {
            bool isVR = Networking.LocalPlayer.IsUserInVR();
            switch (mode) {
                case Mode.VR:
                    gameObject.SetActive(isVR);
                    break;
                case Mode.Desktop:
                    gameObject.SetActive(!isVR);
                    break;
            }
        }
    }
}