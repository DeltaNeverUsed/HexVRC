// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.LogicalOperators {
    public static class Ternary {
        public const string Path = "awdd";

        #region Docs

        public const string Description = "If the first argument is True, keeps the second and discards the third; otherwise discards the second and keeps the third.";

        public const string Input = "Boolean, Any, Any";
        public const string Output = "Any";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, bool chooser, StackItem i1, StackItem i2) {
            info.Stack.Push(chooser ? i1 : i2);
            return ExecutionState.Ok();
        }
    }
}