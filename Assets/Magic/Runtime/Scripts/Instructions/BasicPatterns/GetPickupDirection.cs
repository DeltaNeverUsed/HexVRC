using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class GetPickupDirection {
        public const string Path = "eeeeawa";
        
        #region Docs
        
        public const string Description = "Gets the rotation of the casting object your holding";
        public const string Input = "";
        public const string Output = "Vector";

        #endregion
        
        public static ExecutionState Execute(ExecutionInfo info) {
            Transform executionTransform = info.VM.ExecutionTransform;
            if (!Utilities.IsValid(executionTransform))
                return ExecutionState.Err("executionTransform was invalid");
            
            info.Stack.Push(new StackItem(executionTransform.rotation * Vector3.forward));
            return ExecutionState.Ok();
        }
    }
}

