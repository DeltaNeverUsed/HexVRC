using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class SetPlayerHeight {
        public const string Path = "dwe";

        #region Docs

        public const string Description = "Sets the player's height";
        public const string Input = "Player, Number";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player, float height) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");
            
            info.VM.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(info.VM.SetHeight), player, height);
            return ExecutionState.Ok();
        }
    }
}