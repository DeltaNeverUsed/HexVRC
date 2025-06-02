using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class VectorYp {
        public const string Path = "qqqqqew";

        #region Docs

        public const string Description = "Vector (0,1,0)";
        public const string Input = "";
        public const string Output = "Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(new StackItem(new Vector3(0,1,0)));
            return ExecutionState.Ok();
        }
    }
}