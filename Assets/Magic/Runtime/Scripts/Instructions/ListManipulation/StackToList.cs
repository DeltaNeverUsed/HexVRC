using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class StackToList {
        public const string Path = "ewdqdwe";

        #region Docs

        public const string Description =
            "Remove num elements from the stack, then add them to a list at the top of the stack.";

        public const string Input = "Number";
        public const string Output = "List";

        #endregion

        // /\_/\
        // ( o.o )
        // > ^ <

        public static ExecutionState Execute(ExecutionInfo info, float length) {
            // Get the size of the list to be created
            int size = (int)length;

            // Check if the size is negative
            if (size < 0)
                return ExecutionState.Err("Cannot create list with negative size.");

            // Check if there are enough elements on the stack
            if (info.Stack.Count < size)
                return ExecutionState.Err(
                    $"Not enough elements on the stack. Needed {size}, but only {info.Stack.Count} available.");

            // Create a new array and add the elements from the stack to it
            StackItem[] array = new StackItem[size];
            for (int i = size - 1; i >= 0; i--) {
                array[i] = info.Stack.Pop();
            }

            // Push the list onto the stack
            info.Stack.Push(new StackItem(new List<StackItem>(array)));
            return ExecutionState.Ok();
        }
    }
}