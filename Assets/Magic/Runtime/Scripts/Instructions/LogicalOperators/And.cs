// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.LogicalOperators {
    public static class And {
        public const string Path = "wdw";

        #region Docs

        public const string Description = "Returns True if both arguments are true; otherwise returns False.";

        public const string Input = "Boolean, Boolean";
        public const string Output = "Boolean";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, bool v1, bool v2) {
            info.Stack.Push(new StackItem(v1 && v2));
            return ExecutionState.Ok();
        }
    }
}