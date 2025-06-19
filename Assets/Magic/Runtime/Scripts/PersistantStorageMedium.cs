using UdonSharp;
using VRC.SDK3.Components;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class PersistantStorageMedium : StorageMedium {
        public VRCPickup pickup;

        [UdonSynced] private string _data = "";
        private StackItem _item = new StackItem();

        public void Start() {
            if (!Utilities.IsValid(pickup))
                return;
            pickup.pickupable = Networking.IsOwner(gameObject);
        }

        public override bool Write(StackItem data) {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            _item = data;
            _data = _item.Serialize();
            RequestSerialization();
            UpdatePickup();
            return true;
        }

        public override StackItem Read() => _item;

        public override void OnPlayerRestored(VRCPlayerApi player) => OnDeserialization();

        public override void OnDeserialization() {
            _item = StackItem.Deserialize(_data);
            UpdatePickup();
        }

        private void UpdatePickup() {
            if (!Utilities.IsValid(pickup))
                return;

            pickup.InteractionText = _data.Length < 500 ? _item.ToString() : "data too long to display";
        }
    }
}