using System;
using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using VRC.SDK3.Components;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class TemporaryStorageMedium : StorageMedium {
        public VRCPickup pickup;
        
        [UdonSynced] private byte[] _data = Array.Empty<byte>();
        [UdonSynced] private bool _compressed;
        private StackItem _item = new StackItem();

        private CompressorData _compressorData;
        
        public void Start() {
            isWritable = true;
            _compressorData = CompressorData.Get();
        }

        public override bool Write(StackItem data) {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            _item = data;
            _data = _item.Serialize();
            
            _compressed = false;
            if (_data.Length > 999999999) {
                float originalSize = _data.Length;
                _data = Compressor.HuffmanEncode(_data, _compressorData.Codes);
                this.Log($"Serialized with a compression ratio of {originalSize / _data.Length}");

                _compressed = true;
            }
            
            if (_data.Length > 10000)
                _data = new StackItem().Serialize();
            RequestSerialization();
            UpdatePickup();
            UpdateCallback("sm_DataUpdated");
            return true;
        }

        public override StackItem Read() => _item;

        public override void OnDeserialization() {
            _item = StackItem.Deserialize(_compressed ? Compressor.HuffmanDecode(_data, _compressorData.Root) : _data);
            UpdatePickup();
            UpdateCallback("sm_DataUpdated");
        }

        private void UpdatePickup() {
            if (!Utilities.IsValid(pickup))
                return;

            pickup.InteractionText = _data.Length < 500 ? _item.ToString() : "data too long to display";
        }
    }
}