using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class VectorXp {
        public const string Path = "qqqqqea";

        #region Docs

        public const string Description = "Vector (1,0,0)";
        public const string Input = "";
        public const string Output = "Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(new StackItem(new Vector3(1,0,0)));
            return ExecutionState.Ok();
        }
    }
}