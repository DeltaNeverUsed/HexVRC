// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.Entities {
    public static class IsWritable {
        public const string Path = "wdwewewewewewqw";

        #region Docs

        public const string Description = "Gets the writablity of an entity";
        public const string Input = "Entity";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, Entity entity) {
            info.Stack.Push(new StackItem(entity.IsWritable()));
            return ExecutionState.Ok();
        }
    }
}