using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Player {
    public static class IsValid {
        public const string Path = "qaaqqqqaq";

        #region Docs

        public const string Description = "Tells you if the player is a valid player or not";
        public const string Input = "Player";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, object playerObject) {
            if (playerObject.GetType() != typeof(VRCPlayerApi)) {
                info.Stack.Push(false);
                return ExecutionState.Ok();
            }
            
            VRCPlayerApi player = (VRCPlayerApi)playerObject;
            info.Stack.Push(Utilities.IsValid(player) && player.IsValid());
            return ExecutionState.Ok();
        }
    }
}