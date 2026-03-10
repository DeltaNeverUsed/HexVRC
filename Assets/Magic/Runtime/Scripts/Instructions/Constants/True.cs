// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class True {
        public const string Path = "aqae";

        #region Docs

        public const HexDir Direction = HexDir.SOUTH_EAST;
        public const string Description = "True";
        public const string Output = "Boolean";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(new StackItem(true));
            return ExecutionState.Ok();
        }
    }
}