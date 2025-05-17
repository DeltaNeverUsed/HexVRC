using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions {
    public static class PlayerImpulse {
        public const string Path = "awqqqwaqw";

        #region Docs

        public const string Description = "";
        public const string Input = "";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player, Vector3 impulse) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");

            info.VM.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(info.VM.ApplyImpulse), player.playerId, impulse);

            return ExecutionState.Ok();
        }
    }
}