using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class Blink {
        public const string Path = "awqqqwaq";

        #region Docs

        public const string Description = "Remove an Player and length from the stack, then teleport the given Player along its look vector by the given length.";
        public const string Input = "Player, Number";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player, float length) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");

            ExecutionState manaResult = info.VM.ConsumeMana(Mathf.Floor(length * 9f / 2f));
            if (!manaResult.IsOk())
                return manaResult;

            info.VM.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(info.VM.Blink), player.playerId, length);
            return ExecutionState.Ok();
        }
    }
}