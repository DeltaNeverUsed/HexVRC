using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class DuplicateSecond {
        public const string Path = "aaedd";

        #region Docs

        public const string Description =
            "Copy the second-to-last iota of the stack to the top. [0, 1] becomes [0, 1, 0].";

        public const string Input = "Any, Any";
        public const string Output = "Any, Any, Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, object bot, object top) {
            info.Stack.Push(StackItem.CreateStackItem(bot));
            info.Stack.Push(StackItem.CreateStackItem(top));
            info.Stack.Push(StackItem.CreateStackItem(bot));
            return ExecutionState.Ok();
        }
    }
}