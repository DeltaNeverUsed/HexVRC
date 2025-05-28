using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class InsertAt0 {
        public const string Path = "ddewedd";

        #region Docs

        public const string Description = "Inserts an item into the first slot of a List";

        public const string Input = "List, Any";
        public const string Output = "List";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> stackItems, StackItem item) {
            stackItems.Insert(0, item);
            info.Stack.Push(new StackItem(stackItems));
            return ExecutionState.Ok();
        }
    }
}