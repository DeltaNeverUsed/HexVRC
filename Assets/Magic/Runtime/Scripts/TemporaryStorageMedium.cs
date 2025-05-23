
using UdonSharp;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class TemporaryStorageMedium : StorageMedium {

        [UdonSynced] private string _data = "";
        
        public override bool Write(StackItem data) {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            _data = data.Serialize();
            RequestSerialization();
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
    }
}