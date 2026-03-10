// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.ReadingAndWriting {
    public static class ReadEntity {
        public const string Path = "wawqwqwqwqwqw";

        #region Docs

        public const HexDir Direction = HexDir.EAST;
        public const string Description = "Reads an item from an entity";
        public const string Output = "Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, Entity entity) {
            ExecutionState success = entity.Read(out StackItem data);
            if (success.IsOk())
                info.Stack.Push(data);
            return success;
        }
    }
}