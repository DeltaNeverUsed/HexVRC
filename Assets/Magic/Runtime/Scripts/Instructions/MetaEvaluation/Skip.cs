
// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.EscapingPatterns {
    public static class Skip {
        public const string Path = "aqdee";

        #region Docs

        public const string Description = "breaks out of the current executing pattern list while still executing any parent pattern lists";
        public const string Input = "";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            return ExecutionState.OkEarlyReturn(2);
        }
    }
}