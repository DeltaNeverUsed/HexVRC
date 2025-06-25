using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class GetEyePosition {
        public const string Path = "aa";

        #region Docs

        public const string Description = "Transform a Player or Entity into their Eye's position";
        public const string Input = "Player | Entity";
        public const string Output = "Vector";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");

            info.Stack.Push(new StackItem(player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position));
            return ExecutionState.Ok();
        }
        
        public static ExecutionState Execute(ExecutionInfo info, Entity entity) {
            info.Stack.Push(new StackItem(entity.eyeOverride.position));
            return ExecutionState.Ok();
        }
    }
}