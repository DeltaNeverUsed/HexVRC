using UdonSharp;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class StorageMedium : UdonSharpBehaviour {
        public object Item;

        public bool Write(object data) {
            Item = data;
            return true;
        }

        public bool Read(out object data) {
            data = Item;
            return true;
        }
    }
}