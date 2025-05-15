using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class GetLocalPlayer {
        public const string Path = "qaq";

        #region Docs
        
        public const string Description = "Adds yourself to the stack";
        public const string Input = "";
        public const string Output = "Player";

        #endregion
        
        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(StackItem.CreateStackItem(Networking.LocalPlayer));
            return ExecutionState.Ok();
        }
    }
}