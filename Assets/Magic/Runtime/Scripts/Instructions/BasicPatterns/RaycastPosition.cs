using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class RaycastPosition {
        public const string Path = "wqaawdd";
        
        #region Docs
        
        public const string Description = "Combines two vectors (a position and a direction) into the answer to the question: If I stood at the position and looked in the direction, what position would I be looking at?";
        public const string Input = "Vector, Vector";
        public const string Output = "Vector | Null";

        #endregion
        
        public static ExecutionState Execute(ExecutionInfo info, Vector3 position, Vector3 lookDirection) {
            lookDirection = lookDirection.normalized;

            info.Stack.Push(Physics.Raycast(position, lookDirection, out RaycastHit hit, 100)
                ? StackItem.CreateStackItem(hit.point)
                : StackItem.CreateNullStackItem());

            return ExecutionState.Ok();
        }
    }
}

