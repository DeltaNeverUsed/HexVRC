using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class GetPlayerHeight {
        public const string Path = "awq";

        #region Docs

        public const string Description = "Transforms a player into it's height";
        public const string Input = "Player";
        public const string Output = "Number";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");
            
            info.Stack.Push(StackItem.CreateStackItem(player.GetAvatarEyeHeightAsMeters()));
            return ExecutionState.Ok();
        }
    }
}