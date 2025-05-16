using VRC.SDKBase;
using System.Collections.Generic;
// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation
{
    public static class ListToStack
    {
        public const string Path = "qwaeawq";

        #region Docs

        public const string Description = "Remove the list at the top of the stack, then push its contents to the stack.";
        public const string Input = "List";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<object> stackitems)
        {
            // Push each element in order
            for (int i = 0; i < stackitems.Count; i++)
            {
                info.Stack.Push(StackItem.CreateStackItem(stackitems[i]));
            }
            return ExecutionState.Ok();
        }
    }
} 