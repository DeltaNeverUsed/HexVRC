using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Sets {
    public static class Deduplicate {
        public const string Path = "aweaqa";

        #region Docs

        public const string Description = "Removes duplicate entries from a list.";

        public const string Input = "List";
        public const string Output = "List";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> l) {
            List<StackItem> uniqueList = new List<StackItem>();
            foreach (StackItem item in l) {
                if (uniqueList.Contains(item))
                    continue; // slow and bad
                uniqueList.Add(item);
            }

            info.Stack.Push(new StackItem(uniqueList));
            return ExecutionState.Ok();
        }
    }
}