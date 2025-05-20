// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.LogicalOperators {
    public static class IsSomething {
        public const string Path = "aw";

        #region Docs

        public const string Description = "Convert an argument to a boolean. The number 0, Null, False, and the empty list become False; everything else becomes True.";
        public const string Input = "Any";
        public const string Output = "Boolean";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, StackItem any) {

            return ExecutionState.Ok();
        }
    }
}