using System;
using UdonSharp;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public abstract class StorageMedium : UdonSharpBehaviour {
        public VMManager vm;

        public UdonSharpBehaviour[] callbacks = Array.Empty<UdonSharpBehaviour>();

        public bool isWritable = false;

        public virtual void UpdateCallback(string callbackName) {
            foreach (UdonSharpBehaviour callback in callbacks)
                callback.SendCustomEvent(callbackName);
        }
        
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