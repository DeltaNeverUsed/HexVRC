using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class RaycastNormal {
        public const string Path = "weddwaa";

        #region Docs

        public const HexDir Direction = HexDir.EAST;
        public const string Description =
            "Combines two vectors (a position and a direction) into the answer to the question: If I stood at the position and looked in the direction, what position would I be looking at?";
        public const string Output = "Vector | Null";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, Vector3 position, Vector3 lookDirection) {
            lookDirection = lookDirection.normalized;

            if (Physics.Raycast(position, lookDirection, out RaycastHit hit, 100))
                info.Stack.Push(new StackItem(hit.normal));
            else
                info.Stack.Push(new StackItem());

            return ExecutionState.Ok();
        }
    }
}