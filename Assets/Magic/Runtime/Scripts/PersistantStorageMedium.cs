using UdonSharp;
using VRC.SDK3.Components;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class PersistantStorageMedium : StorageMedium {
        public VRCPickup pickup;
        
        [UdonSynced] private string _data = "";

        public void Start() {
            if (!Utilities.IsValid(pickup))
                return;
            pickup.pickupable = Networking.IsOwner(gameObject);
        }

        public override bool Write(StackItem data) {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            _data = data.Serialize();
            RequestSerialization();
            UpdatePickup();
            return true;
        }

        public override bool Read(out StackItem data) {
            if (string.IsNullOrWhiteSpace(_data)) {
                data = new StackItem();
                return false;
            }

            data = StackItem.Deserialize(_data);
            return true;
        }

        public override void OnPlayerRestored(VRCPlayerApi player) => UpdatePickup();
        public override void OnDeserialization() => UpdatePickup();

        private void UpdatePickup() {
            if (!Utilities.IsValid(pickup))
                return;
            pickup.InteractionText = _data;
        }
    }
}