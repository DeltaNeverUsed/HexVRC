using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class ReverseList {
        public const string Path = "qqqaede";

        #region Docs

        public const string Description = "Reverse the list at the top of the stack.";
        public const string Input = "List";
        public const string Output = "List";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> original) {
            original.Reverse();
            info.Stack.Push(new StackItem(original));
            return ExecutionState.Ok();
        }
    }
}