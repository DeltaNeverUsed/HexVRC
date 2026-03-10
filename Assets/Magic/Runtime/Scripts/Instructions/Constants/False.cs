// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class False {
        public const string Path = "dedq";

        #region Docs

        public const HexDir Direction = HexDir.NORTH_EAST;
        public const string Description = "False";
        public const string Output = "Boolean";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(new StackItem(false));
            return ExecutionState.Ok();
        }
    }
}