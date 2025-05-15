using VRC.SDKBase;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class SetPlayerHeight {
        public const string Path = "dwe";

        #region Docs

        public const string Description = "Sets the player's height";
        public const string Input = "Player, Number";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(Stack<StackItem> stack, VRCPlayerApi player, float height) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");
            
            player.SetAvatarEyeHeightByMeters(height);
            return ExecutionState.Ok();
        }
    }
}