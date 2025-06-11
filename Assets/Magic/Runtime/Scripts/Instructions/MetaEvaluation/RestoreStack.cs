
// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.MetaEvaluation {
    public static class RestoreStack {
        public const string Path = "RestoreStack";

        #region Docs

        public const string Description = "Special Instruction";
        public const string Input = "";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.VM.RestoreStack();
            return ExecutionState.Ok();
        }
    }
}