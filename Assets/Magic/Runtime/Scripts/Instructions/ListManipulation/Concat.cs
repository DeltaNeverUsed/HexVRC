using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class Concat {
        public const string Path = "waaww";

        #region Docs

        public const string Description = "Remove the list at the top of the stack, then add all its elements to the end of the list at the top of the stack.";

        public const string Input = "List, List";
        public const string Output = "List";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> l1, List<StackItem> l2) {
            l1.AddRange(l2);
            info.Stack.Push(new StackItem(l1));
            return ExecutionState.Ok();
        }
    }
}