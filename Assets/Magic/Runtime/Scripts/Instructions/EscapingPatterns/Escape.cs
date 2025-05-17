// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.EscapingPatterns {
    public static class Escape {
        public const string Path = "qqqaw";

        #region Docs

        public const string Description = "Adds to next Symbol to the stack instead of trying to execute it";
        public const string Input = "";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.VM.EscapeNext = true;
            return ExecutionState.Ok();
        }
    }
}