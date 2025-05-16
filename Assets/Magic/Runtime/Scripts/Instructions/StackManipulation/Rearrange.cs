using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class Rearrange {
        public const string Path = "qaawdde";

        #region Docs

        public const string Description =
            "Rearranges the top elements of the stack based on the given numerical code, which is the index of the permutation wanted.";

        public const string Input = "Many, Number";
        public const string Output = "Many";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, object top) {
            return ExecutionState.Err("Not implemented");
        }
    }
}