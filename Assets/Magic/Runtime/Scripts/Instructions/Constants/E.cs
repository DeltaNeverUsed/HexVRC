// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class E {
        public const string Path = "aaq";

        #region Docs

        public const string Description = "e";
        public const string Input = "";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(new StackItem(2.7182817f));
            return ExecutionState.Ok();
        }
    }
}