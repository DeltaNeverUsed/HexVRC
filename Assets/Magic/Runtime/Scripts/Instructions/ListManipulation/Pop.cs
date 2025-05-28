using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class Pop {
        public const string Path = "qaeaq";

        #region Docs

        public const string Description = "Pops the item at the top of the list onto the stack";

        public const string Input = "List";
        public const string Output = "Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> stackItems) {
            int stackEnd = stackItems.Count - 1;
            if (stackEnd < 0)
                return ExecutionState.Err("List is empty");
            
            info.Stack.Push(stackItems[stackEnd]);
            stackItems.RemoveAt(stackEnd);
            return ExecutionState.Ok();
        }
    }
}