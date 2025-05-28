// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.LogicalOperators {
    public static class GreaterThanEqual {
        public const string Path = "ee";

        #region Docs

        public const string Description = "If the first argument is greater than or equal to the second, return True. Otherwise, return False.";

        public const string Input = "Number, Number";
        public const string Output = "Boolean";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float v1, float v2) {
            info.Stack.Push(new StackItem(v1 >= v2));
            return ExecutionState.Ok();
        }
    }
}