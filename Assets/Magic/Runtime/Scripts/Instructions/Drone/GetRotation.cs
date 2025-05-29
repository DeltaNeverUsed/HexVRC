using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Drone {
    public static class GetRotation {
        public const string Path = "ddwwddwewa";

        #region Docs

        public const string Description = "Get Drone's facing direction";
        public const string Input = "Drone";
        public const string Output = "Vector | Null";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCDroneApi drone) {
            if (!Utilities.IsValid(drone))
                return ExecutionState.Err("Invalid drone");

            info.Stack.Push(drone.TryGetRotation(out Quaternion value) ? new StackItem(value * Vector3.forward) : new StackItem());
            return ExecutionState.Ok();
        }
    }
}