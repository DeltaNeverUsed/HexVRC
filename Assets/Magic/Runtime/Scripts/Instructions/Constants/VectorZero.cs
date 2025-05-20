using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class VectorZero {
        public const string Path = "qqqqq";

        #region Docs

        public const string Description = "Vector (0,0,0)";
        public const string Input = "";
        public const string Output = "Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(new StackItem(Vector3.zero));
            return ExecutionState.Ok();
        }
    }
}