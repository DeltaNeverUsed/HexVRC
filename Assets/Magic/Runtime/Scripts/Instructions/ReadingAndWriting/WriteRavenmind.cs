// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.ReadingAndWriting {
    public static class WriteRavenmind {
        public const string Path = "eqqwawqaaw";

        #region Docs

        public const string Description =
            "Removes the top iota from the stack, and saves it to my ravenmind, storing it there until I stop casting the Hex.";

        public const string Input = "Any";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, StackItem item) {
            info.VM.Ravenmind = item;
            return ExecutionState.Ok();
        }
    }
}