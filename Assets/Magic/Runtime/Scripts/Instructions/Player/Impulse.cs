using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Player {
    public static class Impulse {
        public const string Path = "awqqqwaqw";

        #region Docs

        public const string Description = "Remove an Player, Drone, or Entity and a direction from the stack, then give a shove to the given entity in the given direction. The strength of the impulse is determined by the length of the vector.";
        public const string Input = "Player | Drone | Entity, Vector";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player, Vector3 impulse) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");

            ExecutionState manaResult = info.VM.ConsumeMana(Mathf.Floor(Vector3.Magnitude(impulse) * 3));
            if (!manaResult.IsOk())
                return manaResult;

            info.VM.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(info.VM.ApplyImpulse), player.playerId, impulse, false);

            return ExecutionState.Ok();
        }
        
        public static ExecutionState Execute(ExecutionInfo info, VRCDroneApi drone, Vector3 impulse) {
            if (!Utilities.IsValid(drone))
                return ExecutionState.Err("Invalid drone");

            VRCPlayerApi player = drone.GetPlayer();
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");

            ExecutionState manaResult = info.VM.ConsumeMana(Mathf.Floor(Vector3.Magnitude(impulse) * 3));
            if (!manaResult.IsOk())
                return manaResult;

            info.VM.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(info.VM.ApplyImpulse), drone.GetPlayer().playerId, impulse, true);

            return ExecutionState.Ok();
        }
        
        public static ExecutionState Execute(ExecutionInfo info, Entity entity, Vector3 impulse) {
            ExecutionState manaResult = info.VM.ConsumeMana(Mathf.Floor(Vector3.Magnitude(impulse) * 3));
            if (!manaResult.IsOk())
                return manaResult;
            
            return entity.ApplyImpulse(impulse);
        }
    }
}