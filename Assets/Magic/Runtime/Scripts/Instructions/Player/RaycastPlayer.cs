using System.Collections.Generic;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Player {
    public static class GetPlayersNear {
        public const string Path = "qqqqqwdeddwe";

        #region Docs

        public const string Description =
            "Take a position and maximum distance on the stack, and combine them into a list of players near the position.";
        public const string Input = "Vector, Numbeer";
        public const string Output = "List";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, Vector3 position, float maxDistance) {
            VRCPlayerApi[] players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
            VRCPlayerApi.GetPlayers(players);

            List<StackItem> playersClose = new List<StackItem>(players.Length);
            foreach (VRCPlayerApi player in players) {
                if (!Utilities.IsValid(player) || !Utilities.IsValid(player))
                    continue;
                if (Vector3.Distance(player.GetPosition(), position) <= maxDistance)
                    playersClose.Add(new StackItem(player));
            }

            info.Stack.Push(new StackItem(playersClose));
            return ExecutionState.Ok();
        }
    }
}