// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.ReadingAndWriting {
    public static class WriteEntity {
        public const string Path = "wdwewewewewew";

        #region Docs

        public const HexDir Direction = HexDir.EAST;
        public const string Description = "Writes an item to an entity";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, Entity entity, StackItem any) {
            return entity.Write(any);
        }
    }
}