using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation
{
    public static class RotateL
    {
        public const string Path = "ddqdd";

        #region Docs

        public const string Description = "Yanks the top iota to the third position. [0, 1, 2] becomes [2, 0, 1].";
        public const string Input = "Any, Any, Any";
        public const string Output = "Any, Any, Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, object bot, object mid, object top)
        {
            info.Stack.Push(StackItem.CreateStackItem(top));
            info.Stack.Push(StackItem.CreateStackItem(bot));
            info.Stack.Push(StackItem.CreateStackItem(mid));
            return ExecutionState.Ok();
        }
    }
}