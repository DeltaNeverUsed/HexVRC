// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.LogicalOperators {
    public static class Negate {
        public const string Path = "dw";

        #region Docs

        public const string Description = "Negates a boolean";

        public const string Input = "Boolean | Number";
        public const string Output = "Boolean | Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, bool value) {
            info.Stack.Push(new StackItem(!value));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, float value) {
            info.Stack.Push(new StackItem(~(int)value));
            return ExecutionState.Ok();
        }
    }
}