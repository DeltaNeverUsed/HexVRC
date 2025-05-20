using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class RotateL {
        public const string Path = "ddqdd";

        #region Docs

        public const string Description = "Yanks the top iota to the third position. [0, 1, 2] becomes [2, 0, 1].";
        public const string Input = "Any, Any, Any";
        public const string Output = "Any, Any, Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, StackItem bot, StackItem mid, StackItem top) {
            info.Stack.Push(top);
            info.Stack.Push(bot);
            info.Stack.Push(mid);
            return ExecutionState.Ok();
        }
    }
}