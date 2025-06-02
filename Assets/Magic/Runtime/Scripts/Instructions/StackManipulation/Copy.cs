// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class Copy {
        public const string Path = "aadaadaa";

        #region Docs

        public const string Description =
            "Removes the number at the top of the stack, then copies the top iota of the stack that number of times. (A count of 2 results in two of the iota on the stack, not three.)";

        public const string Input = "Any, Number";
        public const string Output = "Many";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, StackItem top, float number) {
            for (int i = 0; i < number; i++) {
                info.Stack.Push(top.Clone());
            }

            return ExecutionState.Ok();
        }
    }
}