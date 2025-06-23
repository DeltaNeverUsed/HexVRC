// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.ReadingAndWriting {
    public static class ReadRavenmind {
        public const string Path = "qeewdweddw";

        #region Docs

        public const string Description = "Copy the iota out of my ravenmind.";

        public const string Input = "";
        public const string Output = "Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(info.VM.Ravenmind);
            return ExecutionState.Ok();
        }
    }
}