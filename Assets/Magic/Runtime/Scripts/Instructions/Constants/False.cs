using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class False
    {
        public const string Path = "dedq";

        #region Docs

        public const string Description = "False";
        public const string Input = "";
        public const string Output = "Boolean";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(StackItem.CreateStackItem(false));
            return ExecutionState.Ok();
        }
    }
}