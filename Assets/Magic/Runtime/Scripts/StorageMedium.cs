using UdonSharp;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public abstract class StorageMedium : UdonSharpBehaviour {
        public VMManager vm;

        public bool isWritable = false;
        
        public virtual bool Write(StackItem data) {
            return false;
        }

        public virtual StackItem Read() {
            return new StackItem();
        }

        public void Pickup() {
            vm.localVM.LastInteractedStorageMedium = this;
        }
    }
}