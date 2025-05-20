using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ReadingAndWriting {
    public static class ReadLast {
        public const string Path = "aqqqqq";

        #region Docs

        public const string Description = "Reads an item from a storage medium";
        public const string Input = "";
        public const string Output = "Any";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info) {
            StorageMedium medium = info.VM.LastInteractedStorageMedium;
            if (!Utilities.IsValid(medium))
                return ExecutionState.Err("No valid storage medium was ever held");
            if (Vector3.Distance(medium.transform.position, Networking.LocalPlayer.GetPosition()) > 5)
                return ExecutionState.Err("Too far away from last held storage medium");

            if (!medium.Read(out StackItem data))
                return ExecutionState.Err("Failed to read?");

            info.Stack.Push(data);
            return ExecutionState.Ok();
        }
    }
}