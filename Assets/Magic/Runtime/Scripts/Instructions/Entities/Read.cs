// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.Entities {
    public static class Read {
        public const string Path = "wawqwqwqwqwqw";

        #region Docs

        public const string Description = "Reads an item from an entity";
        public const string Input = "Entity";
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