using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class GetPlayerEyePosition {
        public const string Path = "aa";

        #region Docs

        public const string Description = "Transform a player into their Eye's position";
        public const string Input = "Player";
        public const string Output = "Vector";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");

            info.Stack.Push(player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position);
            return ExecutionState.Ok();
        }
    }
}