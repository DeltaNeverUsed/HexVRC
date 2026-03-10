// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.LogicalOperators {
    public static class NotEquals {
        public const string Path = "da";

        #region Docs

        public const HexDir Direction = HexDir.EAST;
        public const string Description = "If the first argument equals the second, return True. Otherwise, return False.";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, StackItem i1, StackItem i2) {
            info.Stack.Push(new StackItem(!i1.Equals(i2)));
            return ExecutionState.Ok();
        }
    }
}