using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class SetIndex {
        public const string Path = "wqaeaqw";

        #region Docs

        public const HexDir Direction = HexDir.NORTH_WEST;
        public const string Description =
            "Sets the nth element from a list at a given index";
        public const string Output = "Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> stackItems, float number,
            StackItem item) {
            int index = Mathf.RoundToInt(number);
            if (index < 0 || index >= stackItems.Count)
                info.Stack.Push(new StackItem());
            else {
                stackItems[index] = item;
                info.Stack.Push(new StackItem(stackItems));
            }

            return ExecutionState.Ok();
        }
    }
}