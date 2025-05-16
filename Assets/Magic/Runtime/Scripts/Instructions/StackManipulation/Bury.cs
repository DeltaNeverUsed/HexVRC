using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation
{
    public static class Bury
    {
        public const string Path = "ddqaa";

        #region Docs

        public const string Description = "Copy the top iota of the stack, then put it under the second iota. [0, 1] becomes [1, 0, 1].";
        public const string Input = "Any, Any";
        public const string Output = "Any, Any, Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, object bot, object top)
        {
            
            info.Stack.Push(StackItem.CreateStackItem(top));
            info.Stack.Push(StackItem.CreateStackItem(bot));
            info.Stack.Push(StackItem.CreateStackItem(top));
            return ExecutionState.Ok();
        }
    }
}