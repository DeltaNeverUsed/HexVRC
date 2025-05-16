using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class Swap {
        public const string Path = "aawdd";

        #region Docs

        public const string Description = "Swaps the top two iotas of the stack.";
        public const string Input = "Any, Any";
        public const string Output = "Any, Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, object bot, object top) {
            info.Stack.Push(top);
            info.Stack.Push(bot);
            return ExecutionState.Ok();
        }
    }
}