
// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.EscapingPatterns {
    public static class Halt {
        public const string Path = "None";

        #region Docs

        public const string Description = "Special Instruction";
        public const string Input = "";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            return ExecutionState.OkEarlyReturn(9999);
        }
    }
}