using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.GreatSpells {
    public static class GreaterTeleport {
        public const string Path = "wwwqqqwwwqqeqqwwwqqwqqdqqqqqdqq";

        #region Docs

        public const string Description = "Far more powerful than Blink, this spell lets me teleport nearly anywhere in the entire world! There does seem to be a limit, but it is much greater than the normal radius of influence I am used to.\n\nThe entity will be teleported by the given vector. Curiously, this vector seems to be an offset, not an absolute position in the world; for example, if I use Vector Reflection +X, the entity will end up precisely one block east of its original position. No matter the distance";
        public const string Input = "Player | Entity, Vector";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player, Vector3 vector) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");

            if (vector.magnitude > 100)
                return ExecutionState.Err("Teleportation distance was too great");
            
            ExecutionState manaResult = info.VM.ConsumeMana(50);
            if (!manaResult.IsOk())
                return manaResult;

            info.VM.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(info.VM.GreaterTeleport), player.playerId, vector);
            return ExecutionState.Ok();
        }
        
        public static ExecutionState Execute(ExecutionInfo info, Entity entity, Vector3 vector) {
            if (vector.magnitude > 100)
                return ExecutionState.Err("Teleportation distance was too great");
            
            ExecutionState manaResult = info.VM.ConsumeMana(50);
            if (!manaResult.IsOk())
                return manaResult;

            entity.GreaterTeleport(vector);
            return ExecutionState.Ok();
        }
    }
}