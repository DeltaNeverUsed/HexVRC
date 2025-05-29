using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Drone {
    public static class GetPosition {
        public const string Path = "ddwwdded";

        #region Docs

        public const string Description = "Get Drone position";
        public const string Input = "Drone";
        public const string Output = "Vector | Null";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCDroneApi drone) {
            if (!Utilities.IsValid(drone))
                return ExecutionState.Err("Invalid drone");

            info.Stack.Push(drone.TryGetPosition(out Vector3 value) ? new StackItem(value) : new StackItem());
            return ExecutionState.Ok();
        }
    }
}