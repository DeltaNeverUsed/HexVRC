using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ReadingAndWriting {
    public static class WriteLast {
        public const string Path = "deeeee";

        #region Docs

        public const string Description = "Writes an item to a storage medium";
        public const string Input = "Any";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, StackItem item) {
            StorageMedium medium = info.VM.LastInteractedStorageMedium;
            if (!Utilities.IsValid(medium))
                return ExecutionState.Err("No valid storage medium was ever held");
            if (Vector3.Distance(medium.transform.position, Networking.LocalPlayer.GetPosition()) > 5)
                return ExecutionState.Err("Too far away from last held storage medium");

            if (medium.Write(item))
                return ExecutionState.Ok();
            return ExecutionState.Err("Failed to write?");
        }
    }
}