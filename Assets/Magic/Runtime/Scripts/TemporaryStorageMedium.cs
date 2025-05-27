using UdonSharp;
using VRC.SDK3.Components;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class TemporaryStorageMedium : StorageMedium {
        public VRCPickup pickup;
        
        [UdonSynced] private string _data = "";
        private StackItem _item = new StackItem();

        public override bool Write(StackItem data) {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            _item = data;
            _data = _item.Serialize();
            RequestSerialization();
            UpdatePickup();
            return true;
        }

        public override StackItem Read() => _item;

        public override void OnDeserialization() {
            _item = StackItem.Deserialize(_data);
            UpdatePickup();
        }

        private void UpdatePickup() {
            if (!Utilities.IsValid(pickup))
                return;
            pickup.InteractionText = _item.ToString();
        }
    }
}