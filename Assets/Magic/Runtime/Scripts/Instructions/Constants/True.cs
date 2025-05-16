using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class True
    {
        public const string Path = "aqae";

        #region Docs

        public const string Description = "True";
        public const string Input = "";
        public const string Output = "Boolean";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(StackItem.CreateStackItem(true));
            return ExecutionState.Ok();
        }
    }
}