using System;
using System.Collections.Generic;
using System.Text;
using BefuddledLabs.Magic.Debug.VUdon;
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class StorageMediumImportExport : UdonSharpBehaviour {
        public TMP_InputField textField;
        private StorageMedium _storageMediumInside;

        private int _isEditable;

        private CompressorData compressorData;

        private void Start() {
            compressorData = CompressorData.Get();
        }
        
        public void OnTriggerEnter(Collider other) {
            if (Utilities.IsValid(_storageMediumInside))
                return;

            StorageMedium medium = other.GetComponent<StorageMedium>();
            if (!Utilities.IsValid(medium))
                medium = other.GetComponentInChildren<StorageMedium>();
            if (!Utilities.IsValid(medium))
                medium = other.GetComponentInParent<StorageMedium>();

            if (!Utilities.IsValid(medium))
                return;

            _storageMediumInside = medium;
            ReadText();
        }

        public void OnTriggerExit(Collider other) {
            if (!Utilities.IsValid(_storageMediumInside))
                return;

            StorageMedium medium = other.GetComponent<StorageMedium>();
            if (!Utilities.IsValid(medium))
                medium = other.GetComponentInChildren<StorageMedium>();
            if (!Utilities.IsValid(medium))
                medium = other.GetComponentInParent<StorageMedium>();

            if (!Utilities.IsValid(medium))
                return;

            if (medium == _storageMediumInside)
                _storageMediumInside = null;

            ReadText();
        }

        public void Dec() => _isEditable--;

        public bool IsValidBase64(string input) {
            if (string.IsNullOrEmpty(input)) return false;
            if (input.Length % 4 != 0) return false;

            // Valid Base64 characters: A-Z, a-z, 0-9, +, /, and possibly =
            foreach (char c in input) {
                if (!((c >= 'A' && c <= 'Z') ||
                      (c >= 'a' && c <= 'z') ||
                      (c >= '0' && c <= '9') ||
                      c == '+' || c == '/' || c == '=')) {
                    return false;
                }
            }
            return true;
        }

        public void OnTextUpdate() {
            if (_isEditable != 0)
                return;

            if (!Utilities.IsValid(_storageMediumInside))
                return;

            if (!IsValidBase64(textField.text))
                return;


            byte[] serialized = Convert.FromBase64String(textField.text);
            byte[] huffmanDecoded = Compressor.HuffmanDecode(serialized, compressorData.Root);
            Compressor.DeltaDecode(ref huffmanDecoded);
            Compressor.DeltaDecode(ref huffmanDecoded);
            
            StackItem item = StackItem.Deserialize(huffmanDecoded);
            _storageMediumInside.Write(item);
        }

        public void ReadText() {
            if (!Utilities.IsValid(_storageMediumInside)) {
                textField.readOnly = true;
                textField.text = "";
                return;
            }

            textField.readOnly = false;
            
            byte[] serialized = _storageMediumInside.Read().Serialize();
            
            this.Log(Convert.ToBase64String(serialized));
            Compressor.DeltaEncode(ref serialized);
            Compressor.DeltaEncode(ref serialized);
            byte[] huffmanEncoded = Compressor.HuffmanEncode(serialized, compressorData.Codes);
            this.Log(Convert.ToBase64String(huffmanEncoded));
            byte[] huffmanDecoded = Compressor.HuffmanDecode(huffmanEncoded, compressorData.Root);
            Compressor.DeltaDecode(ref huffmanDecoded);
            Compressor.DeltaDecode(ref huffmanDecoded);
            this.Log(Convert.ToBase64String(huffmanDecoded));
            //this.Log(Convert.ToBase64String(serialized));
            
            textField.text = Convert.ToBase64String(serialized);

            _isEditable++;
            SendCustomEventDelayedFrames(nameof(Dec), 2);
        }
    }
}