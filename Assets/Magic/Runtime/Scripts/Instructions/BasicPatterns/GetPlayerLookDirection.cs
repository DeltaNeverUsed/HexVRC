using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class GetPlayerLookDirection {
        public const string Path = "wa";

        #region Docs

        public const string Description = "Transform a player into the direction they are looking at";
        public const string Input = "Player";
        public const string Output = "Vector";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");

            info.Stack.Push(new StackItem(player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).rotation *
                                          Vector3.forward));
            return ExecutionState.Ok();
        }
    }
}