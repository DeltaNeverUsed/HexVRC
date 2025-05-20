using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class MoveCopy {
        public const string Path = "aada";

        #region Docs

        public const string Description =
            "Grabs the element in the stack indexed by the number and brings it to the top. If the number is negative, instead moves the top element of the stack down that many elements.";

        public const string Input = "Numer";
        public const string Output = "Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, float index) {
            // Implementation of the move instruction
            Stack<StackItem> stack = info.Stack;
            int idx = (int)index;

            Stack<StackItem> scratch = new Stack<StackItem>();

            // If the index is positive, move the element at that index to the top of the stack
            if (idx >= 0) {
                if (stack.Count < idx)
                    return ExecutionState.Err("Index out of range");

                // Pop all elements up to the index into the scratch stack
                for (int i = 0; i < idx; i++)
                    scratch.Push(stack.Pop());

                // Pop the element at the index and keep it for later
                StackItem indexedElement = stack.Peek();

                // Push all elements from the scratch stack back onto the original stack
                while (scratch.Count > 0)
                    stack.Push(scratch.Pop());

                // Push the element at the index back onto the top of the stack
                stack.Push(indexedElement);
            }
            // If the index is negative, move the top element of the stack down that many elements
            else {
                // Convert the index to a positive value
                idx = -idx;

                if (stack.Count < idx)
                    return ExecutionState.Err("Index out of range");

                StackItem topElement = stack.Peek();

                // Pop all elements up to the index into the scratch stack
                for (int i = 0; i <= idx; i++)
                    scratch.Push(stack.Pop());

                // Pop the top element of the stack and push it onto the scratch stack
                stack.Push(topElement);

                // Push all elements from the scratch stack back onto the original stack
                while (scratch.Count > 0)
                    stack.Push(scratch.Pop());
            }

            return ExecutionState.Ok();
        }
    }
}