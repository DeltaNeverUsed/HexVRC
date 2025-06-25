// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.Entities {
    public static class IsReadable {
        public const string Path = "wawqwqwqwqwqwew";

        #region Docs

        public const string Description = "Gets the readablity of an entity";
        public const string Input = "Entity";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, Entity entity) {
            info.Stack.Push(new StackItem(entity.IsWritable()));
            return ExecutionState.Ok();
        }
    }
}