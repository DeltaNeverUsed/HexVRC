using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class StorageMediumExecutor : UdonSharpBehaviour {
        public VMManager vmManager;
        public StorageMedium storageMedium;
        
        public Transform executionTransform;

        public override void OnPickupUseUp() {
            vmManager.localVM.ExecutionTransform = Utilities.IsValid(executionTransform) ? executionTransform : transform;
            ExecutionState result = vmManager.localVM.Execute(storageMedium.Read().ToInstructionList());
            
            this.Log($"execution state was {result.ToString()} and took {vmManager.localVM.GetLastExecutionTimeMs()}ms");
        }
    }
}