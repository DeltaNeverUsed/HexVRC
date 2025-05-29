using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Drone {
    public static class IsDeployed {
        public const string Path = "ddwwddweqq";

        #region Docs

        public const string Description = "Is Drone deployed?";
        public const string Input = "Drone";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCDroneApi drone) {
            if (!Utilities.IsValid(drone))
                return ExecutionState.Err("Invalid drone");
            
            info.Stack.Push(new StackItem(drone.IsDeployed()));
            return ExecutionState.Ok();
        }
    }
}