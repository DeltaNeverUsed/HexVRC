using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
        public static class RaycastPlayer {
            public const string Path = "weaqa";

            #region Docs

            public const string Description = "Combines two vectors (a position and a direction) into the answer to the question: If I stood at the position and looked in the direction, what Player would I be looking at?";
            public const string Input = "Vector, Vector";
            public const string Output = "Player | Null";

            #endregion
            
            public static ExecutionState Execute(ExecutionInfo info, Vector3 position, Vector3 lookDirection) {
                lookDirection = lookDirection.normalized;

                if (!Physics.Raycast(position, lookDirection, out RaycastHit hit, 100)) {
                    info.Stack.Push(StackItem.CreateNullStackItem());
                    return ExecutionState.Ok();
                }

                Vector3 hitPosition = hit.point;

                VRCPlayerApi[] players = new VRCPlayerApi[84];
                VRCPlayerApi.GetPlayers(players);

                VRCPlayerApi closestPlayer = Networking.LocalPlayer;
                float closestDistance = float.MaxValue;
                foreach (VRCPlayerApi player in players) {
                    if (!Utilities.IsValid(player) || !Utilities.IsValid(player))
                        break;

                    Vector3 playerPosition = player.GetPosition();
                    float distance = Vector3.Distance(playerPosition, hitPosition);
                    if (distance < closestDistance) {
                        closestPlayer = player;
                        closestDistance = distance;
                    }
                }

                if (closestDistance >= 3) { // return null if player isn't close
                    info.Stack.Push(StackItem.CreateNullStackItem());
                    return ExecutionState.Ok();
                }
                
                info.Stack.Push(StackItem.CreateStackItem(closestPlayer));
                return ExecutionState.Ok();
            }
        
    }
}