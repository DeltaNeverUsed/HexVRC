// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.ReadingAndWriting {
    public static class IsEntityWritable {
        public const string Path = "wdwewewewewewqw";

        #region Docs

        public const HexDir Direction = HexDir.EAST;
        public const string Description = "Gets the writablity of an entity";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, Entity entity) {
            info.Stack.Push(new StackItem(entity.IsWritable()));
            return ExecutionState.Ok();
        }
    }
}