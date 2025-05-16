// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class Null {
        public const string Path = "d";

        #region Docs

        public const string Description = "Null";
        public const string Input = "";
        public const string Output = "Null";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(null);
            return ExecutionState.Ok();
        }
    }
}