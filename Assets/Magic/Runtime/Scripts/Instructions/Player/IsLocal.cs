using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Player {
    public static class IsLocal {
        public const string Path = "qaaqqq";

        #region Docs

        public const string Description = "Is the player yourself";
        public const string Input = "Player";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");
            
            info.Stack.Push(new StackItem(player.isLocal));
            return ExecutionState.Ok();
        }
    }
}