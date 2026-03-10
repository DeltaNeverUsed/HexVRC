// ReSharper disable once CheckNamespace
using UnityEngine;
using VRC.SDKBase;

namespace BefuddledLabs.Magic.Instructions.ReadingAndWriting {
    public static class IsWritable {
        public const string Path = "deeeeeq";

        #region Docs

        public const HexDir Direction = HexDir.EAST;
        public const string Description = "Gets the writablity of the last held storage medium";
        public const string Output = "Boolean";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info) {
            StorageMedium medium = info.VM.LastInteractedStorageMedium;
            var writable = Utilities.IsValid(medium) &&
                medium.isWritable &&
                Vector3.Distance(medium.transform.position, Networking.LocalPlayer.GetPosition()) <= 5;
            info.Stack.Push(new StackItem(writable));
            return ExecutionState.Ok();
        }
    }
}