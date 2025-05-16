using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class RotateR {
        public const string Path = "aaeaa";

        #region Docs

        public const string Description =
            "Yanks the iota third from the top of the stack to the top. [0, 1, 2] becomes [1, 2, 0].";

        public const string Input = "Any, Any, Any";
        public const string Output = "Any, Any, Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, object bot, object mid, object top) {
            info.Stack.Push(mid);
            info.Stack.Push(top);
            info.Stack.Push(bot);
            return ExecutionState.Ok();
        }
    }
}