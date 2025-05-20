
// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class DuplicateTwice {
        public const string Path = "aadadaaw";

        #region Docs

        public const string Description = "Copy the top two iotas of the stack. [0, 1] becomes [0, 1, 0, 1].";
        public const string Input = "Any, Any";
        public const string Output = "Any, Any, Any, Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, StackItem bot, StackItem top) {
            info.Stack.Push(bot);
            info.Stack.Push(top);
            info.Stack.Push(bot);
            info.Stack.Push(top);
            return ExecutionState.Ok();
        }
    }
}