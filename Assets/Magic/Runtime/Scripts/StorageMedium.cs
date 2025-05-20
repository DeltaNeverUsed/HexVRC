using UdonSharp;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class StorageMedium : UdonSharpBehaviour {
        public VMManager vm;
        public VRC_Pickup pickup;
        
        [UdonSynced] private string _item;

        public bool Write(StackItem data) {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            _item = data.Serialize();
            pickup.InteractionText = data.ToString();
            RequestSerialization();
            return true;
        }

        public bool Read(out StackItem data) {
            data = StackItem.Deserialize(_item);
            return true;
        }

        public void Pickup() {
            vm.localVM.LastInteractedStorageMedium = this;
        }
    }
}