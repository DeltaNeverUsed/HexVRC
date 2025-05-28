using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class CreateListFromAny {
        public const string Path = "adeeed";

        #region Docs

        public const string Description = "Remove the top of the stack, then push a list containing only that element.";

        public const string Input = "Any";
        public const string Output = "List";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, StackItem item) {
            List<StackItem> list = new List<StackItem>();
            list.Add(item);
            info.Stack.Push(new StackItem(list));
            return ExecutionState.Ok();
        }
    }
}