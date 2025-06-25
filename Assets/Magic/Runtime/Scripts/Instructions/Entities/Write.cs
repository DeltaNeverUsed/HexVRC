// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.Entities {
    public static class Write {
        public const string Path = "wdwewewewewew";

        #region Docs

        public const string Description = "Writes an item to an entity";
        public const string Input = "Entity, Any";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, Entity entity, StackItem any) {
            return entity.Write(any);
        }
    }
}