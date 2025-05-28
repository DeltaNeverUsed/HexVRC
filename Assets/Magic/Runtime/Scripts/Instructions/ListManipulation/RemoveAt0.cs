using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class RemoveAt0 {
        public const string Path = "aaqwqaa";

        #region Docs

        public const string Description = "Removes the first item of a List and pushes it onto the stack";

        public const string Input = "List";
        public const string Output = "Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> stackItems) {
            if (stackItems.Count <= 0)
                return ExecutionState.Err("List is empty");
            
            info.Stack.Push(stackItems[0]);
            stackItems.RemoveAt(0);
            return ExecutionState.Ok();
        }
    }
}