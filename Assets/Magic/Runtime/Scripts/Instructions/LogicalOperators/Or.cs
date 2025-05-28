// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.LogicalOperators {
    public static class Or {
        public const string Path = "waw";

        #region Docs

        public const string Description = "Returns True if at least one of the arguments are True; otherwise returns False.";

        public const string Input = "Boolean, Boolean";
        public const string Output = "Boolean";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, bool v1, bool v2) {
            info.Stack.Push(new StackItem(v1 || v2));
            return ExecutionState.Ok();
        }
    }
}