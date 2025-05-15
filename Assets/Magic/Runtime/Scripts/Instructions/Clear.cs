
// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions {
    public static class Clear {
        public const string Path = "eeeeedw";
        
        #region Docs
        
        public const string Description = "Clears the stack and the Glyph space";
        public const string Input = "";
        public const string Output = "";

        #endregion
        
        public static ExecutionState Execute(ExecutionInfo info) {
            info.VM.ResetVM();
            return ExecutionState.Ok();
        }
    }
}