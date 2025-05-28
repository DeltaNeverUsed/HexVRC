using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class CreateList {
        public const string Path = "qqaeaae";

        #region Docs

        public const string Description = "Adds an empty list to the stack";

        public const string Input = "";
        public const string Output = "List";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(new StackItem(new List<StackItem>()));
            return ExecutionState.Ok();
        }
    }
}