using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Player {
    public static class IsPlayerGrounded {
        public const string Path = "qaaqeq";

        #region Docs

        public const string Description = "Whether the player is grounded";
        public const string Input = "Player";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");
            
            info.Stack.Push(player.IsPlayerGrounded());
            return ExecutionState.Ok();
        }
    }
}