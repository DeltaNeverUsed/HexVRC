using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Player {
    public static class IsSuspended {
        public const string Path = "qaaqe";

        #region Docs

        public const string Description = "Tells you if the player's device is suspended. A device is suspended if it enters sleep mode or switches to a different app. While suspended, devices don't run Udon code or respond to network events until the player reopens VRChat.";
        public const string Input = "Player";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");
            
            info.Stack.Push(new StackItem(player.isSuspended));
            return ExecutionState.Ok();
        }
    }
}