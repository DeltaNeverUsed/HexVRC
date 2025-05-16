using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class StackSize {
        public const string Path = "qwaeawqaeaqa";

        #region Docs

        public const string Description =
            "Pushes the size of the stack as a number to the top of the stack. (For example, a stack of [0, 1] will become [0, 1, 2].)";

        public const string Input = "";
        public const string Output = "Number";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, object top, float number) {
            info.Stack.Push((float)info.Stack.Count);
            return ExecutionState.Ok();
        }
    }
}