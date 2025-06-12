
// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.MetaEvaluation {
    public static class SaveStack {
        public const string Path = "SaveStack";

        #region Docs

        public const string Description = "Special Instruction";
        public const string Input = "";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            return info.VM.SaveStack();
        }
    }
}