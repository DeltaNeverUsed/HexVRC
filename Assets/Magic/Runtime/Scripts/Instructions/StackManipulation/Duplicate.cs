
// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class Duplicate {
        public const string Path = "aadaa";

        #region Docs

        public const string Description = "Duplicates the top iota of the stack.";
        public const string Input = "Any";
        public const string Output = "Any, Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, StackItem top) {
            info.Stack.Push(top.Copy());
            info.Stack.Push(top.Copy());
            return ExecutionState.Ok();
        }
    }
}