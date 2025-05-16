using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class Pi
    {
        public const string Path = "qdwdq";

        #region Docs

        public const string Description = "Pi";
        public const string Input = "";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(StackItem.CreateStackItem(Mathf.PI));
            return ExecutionState.Ok();
        }
    }
}