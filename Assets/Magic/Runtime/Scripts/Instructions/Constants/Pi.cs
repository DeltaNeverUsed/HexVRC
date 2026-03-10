using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class Pi {
        public const string Path = "qdwdq";

        #region Docs

        public const HexDir Direction = HexDir.NORTH_EAST;
        public const string Description = "Pi";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(new StackItem(Mathf.PI));
            return ExecutionState.Ok();
        }
    }
}