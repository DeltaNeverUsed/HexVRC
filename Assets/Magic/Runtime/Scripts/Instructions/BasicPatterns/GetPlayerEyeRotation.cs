using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class GetPlayerEyeRotation {
        public const string Path = "dd";
        
        #region Docs
        
        public const string Description = "Transform a player into their position";
        public const string Input = "Player";
        public const string Output = "Vector";

        #endregion
        
        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");
            
            info.Stack.Push(new StackItem(player.GetPosition()));
            return ExecutionState.Ok();
        }
    }
}

