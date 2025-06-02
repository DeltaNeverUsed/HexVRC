using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class VectorZn {
        public const string Path = "eeeeeqd";

        #region Docs

        public const string Description = "Vector (0,0,-1)";
        public const string Input = "";
        public const string Output = "Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(new StackItem(new Vector3(0,0,-1)));
            return ExecutionState.Ok();
        }
    }
}