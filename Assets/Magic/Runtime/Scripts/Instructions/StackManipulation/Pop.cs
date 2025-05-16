using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation
{
    public static class Pop
    {
        public const string Path = "a";

        #region Docs

        public const string Description = "Removes the first iota from the stack.";
        public const string Input = "Any";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, object top)
        {
            return ExecutionState.Ok();
        }
    }
}