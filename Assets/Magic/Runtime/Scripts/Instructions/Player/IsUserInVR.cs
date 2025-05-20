using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Player {
    public static class IsUserInVR {
        public const string Path = "qaaqqaaq";

        #region Docs

        public const string Description = "Tells you if the player is in VR";
        public const string Input = "Player";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");
            
            info.Stack.Push(player.IsUserInVR());
            return ExecutionState.Ok();
        }
    }
}