using System;
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

        public void OnTextUpdate() {
            if (_isEditable != 0)
                return;
            
            if (!Utilities.IsValid(_storageMediumInside))
                return;

            StackItem item = StackItem.Deserialize(Convert.FromBase64String(textField.text));
            _storageMediumInside.Write(item);
        }

        public void ReadText() {
            if (!Utilities.IsValid(_storageMediumInside)) {
                textField.readOnly = true;
                textField.text = "";
                return;
            }
            textField.readOnly = false;
            textField.text = Convert.ToBase64String(_storageMediumInside.Read().Serialize());

            _isEditable++;
            SendCustomEventDelayedFrames(nameof(Dec), 2);
        }
    }
}