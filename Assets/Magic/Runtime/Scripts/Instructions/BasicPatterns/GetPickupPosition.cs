using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class GetPickupPosition {
        public const string Path = "eeeeaa";
        
        #region Docs
        
        public const string Description = "Gets the position of the casting object your holding";
        public const string Input = "";
        public const string Output = "Vector";

        #endregion
        
        public static ExecutionState Execute(ExecutionInfo info) {
            Transform executionTransform = info.VM.ExecutionTransform;
            if (!Utilities.IsValid(executionTransform))
                return ExecutionState.Err("executionTransform was invalid");
            
            info.Stack.Push(new StackItem(executionTransform.position));
            return ExecutionState.Ok();
        }
    }
}

