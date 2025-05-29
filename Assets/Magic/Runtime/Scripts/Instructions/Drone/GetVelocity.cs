using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Drone {
    public static class GetVelocity {
        public const string Path = "ddwwddad";

        #region Docs

        public const string Description = "Get Drone's velocity";
        public const string Input = "Drone";
        public const string Output = "Vector | Null";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCDroneApi drone) {
            if (!Utilities.IsValid(drone))
                return ExecutionState.Err("Invalid drone");

            info.Stack.Push(drone.TryGetVelocity(out Vector3 value) ? new StackItem(value) : new StackItem());
            return ExecutionState.Ok();
        }
    }
}