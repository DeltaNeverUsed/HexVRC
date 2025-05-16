using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.NumberLiterals {
    public static class NumberLiteralNegative {
        public const string Path = "dedd*";

        #region Docs
        
        public const string Description = "Adds a negative Number to the stack";
        public const string Input = "";
        public const string Output = "Number";

        #endregion
        
        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(StackItem.CreateStackItem(-NumberLiteralPositive.PathToNumber(info.Path)));

            return ExecutionState.Ok();
        }
    }
}