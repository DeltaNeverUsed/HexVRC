// ReSharper disable once CheckNamespace
using UnityEngine;
using VRC.SDKBase;

namespace BefuddledLabs.Magic.Instructions.ReadingAndWriting {
    public static class IsReadable {
        public const string Path = "aqqqqqe";

        #region Docs

        public const HexDir Direction = HexDir.EAST;
        public const string Description = "Gets the readability of the last held storage medium";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info) {
            StorageMedium medium = info.VM.LastInteractedStorageMedium;
            var readable = Utilities.IsValid(medium) &&
                Vector3.Distance(medium.transform.position, Networking.LocalPlayer.GetPosition()) <= 5;
            info.Stack.Push(new StackItem(readable));
            return ExecutionState.Ok();
        }
    }
}