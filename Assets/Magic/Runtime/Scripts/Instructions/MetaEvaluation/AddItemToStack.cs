

using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.MetaEvaluation {
    public static class AddItemToStack {
        public const string Path = "AddItemToStack";

        #region Docs

        public const string Description = "Special Instruction";
        public const string Input = "";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            object extraData = info.VM.CurrentInstructions[info.CurrentInstructionIndex].ExtraData;
            if (!Utilities.IsValid(extraData))
                return ExecutionState.Err("Extra data is null");
            
            info.Stack.Push((StackItem)extraData);
            return ExecutionState.Ok();
        }
    }
}