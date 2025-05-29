using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Drone {
    public static class GetDrone {
        public const string Path = "ddwwddwa";

        #region Docs

        public const string Description = "Get player drone";
        public const string Input = "Player";
        public const string Output = "Drone | Null";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return ExecutionState.Err("Invalid player");
            
            info.Stack.Push(new StackItem(player.GetDrone()));
            return ExecutionState.Ok();
        }
    }
}