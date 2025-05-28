using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class IndexOf {
        public const string Path = "dedqde";

        #region Docs

        public const string Description = "Gets the Index of an element in a List";

        public const string Input = "List, Any";
        public const string Output = "Number";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> l, StackItem item) {
            info.Stack.Push(new StackItem(l.IndexOf(item)));
            return ExecutionState.Ok();
        }
    }
}