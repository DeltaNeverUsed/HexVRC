using UdonSharp;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public abstract class StorageMedium : UdonSharpBehaviour {
        public VMManager vm;
        
        public virtual bool Write(StackItem data) {
            return false;
        }

        public virtual bool Read(out StackItem data) {
            data = new StackItem();
            return false;
        }

        public void Pickup() {
            vm.localVM.LastInteractedStorageMedium = this;
        }
    }
}