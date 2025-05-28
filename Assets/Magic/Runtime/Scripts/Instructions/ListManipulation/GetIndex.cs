using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class GetIndex {
        public const string Path = "deeed";

        #region Docs

        public const string Description =
            "Gets the item at index in list";

        public const string Input = "List, Number";
        public const string Output = "Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> stackItems, float number) {
            int index = Mathf.RoundToInt(number);
            if (index < 0 && index >= stackItems.Count)
                info.Stack.Push(new StackItem());
            else
                info.Stack.Push(stackItems[index]);

            return ExecutionState.Ok();
        }
    }
}