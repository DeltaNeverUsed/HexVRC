using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Player {
    public static class PlayHapticEventInRightHand {
        public const string Path = "qaaqeada";

        #region Docs

        public const string Description =
            "Vibrate the Player's Haptic controllers if they have them. The float inputs should be in the range 0-1. duration is the amount of time that they vibrate, amplitude is the strength with which they vibrate, and frequency is the speed at which they vibrate. The feeling can vary quite a bit between controllers.";

        public const string Input = "Player, Number, Number, Number";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player, float duration, float amplitude,
            float frequency) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");
            
            ExecutionState manaResult = info.VM.ConsumeMana(duration * amplitude);
            if (!manaResult.IsOk())
                return manaResult;

            duration = Mathf.Clamp(duration, 0f, 1f);
            amplitude = Mathf.Clamp(amplitude, 0f, 1f);
            frequency = Mathf.Clamp(frequency, 0f, 1f);

            player.PlayHapticEventInHand(VRC_Pickup.PickupHand.Right, duration, amplitude, frequency);
            return ExecutionState.Ok();
        }
    }
}