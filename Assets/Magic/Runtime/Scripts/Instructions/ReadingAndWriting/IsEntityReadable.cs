// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.ReadingAndWriting {
    public static class IsEntityReadable {
        public const string Path = "wawqwqwqwqwqwew";

        #region Docs

        public const HexDir Direction = HexDir.EAST;
        public const string Description = "Gets the readablity of an entity";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, Entity entity) {
            info.Stack.Push(new StackItem(entity.IsReadable()));
            return ExecutionState.Ok();
        }
    }
}