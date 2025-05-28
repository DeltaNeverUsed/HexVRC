using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class Push {
        public const string Path = "edqde";

        #region Docs

        public const string Description = "Appends an item to a list";

        public const string Input = "List, Any";
        public const string Output = "List";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> stackItems, StackItem item) {
            stackItems.Add(item);
            info.Stack.Push(new StackItem(stackItems));
            return ExecutionState.Ok();
        }
    }
}