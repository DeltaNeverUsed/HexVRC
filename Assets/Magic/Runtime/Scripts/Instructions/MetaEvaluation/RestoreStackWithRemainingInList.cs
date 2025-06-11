using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.MetaEvaluation {
    public static class RestoreStackWithRemainingInList {
        public const string Path = "RestoreStackWithRemainingInList";

        #region Docs

        public const string Description = "Special Instruction";
        public const string Input = "";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            StackItem[] remaining = info.Stack.ToArray();
            info.VM.RestoreStack();
            Stack<StackItem> oldStack = info.Stack;
            if (oldStack.Count > 0) {
                StackItem stackItem = oldStack.Pop();
                if (stackItem.Type == ItemType.List) {
                    List<StackItem> stackList = (List<StackItem>)stackItem.Value;
                    ListHelpers.InsertList(ref stackList, new List<StackItem>(remaining), stackList.Count);
                    oldStack.Push(new StackItem(stackList));
                }
                else
                    oldStack.Push(new StackItem(new List<StackItem>(remaining))); // this is bad practice... but the TryPop function doesn't work properly
            }
            else
                oldStack.Push(new StackItem(new List<StackItem>(remaining)));
            return ExecutionState.Ok();
        }
    }
}