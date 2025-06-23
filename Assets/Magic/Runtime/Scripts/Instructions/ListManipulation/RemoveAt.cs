using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class RemoveAt {
        public const string Path = "edqdewaqa";

        #region Docs

        public const string Description = "Remove's the nth element from a list";

        public const string Input = "List, Number";
        public const string Output = "List";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> l, float indexFloat) {
            int index = Mathf.RoundToInt(indexFloat);
            if (index < 0 || index >= l.Count)
                ExecutionState.Err("Index out of range");

            l.RemoveAt(index);
            info.Stack.Push(new StackItem(l));
            return ExecutionState.Ok();
        }
    }
}