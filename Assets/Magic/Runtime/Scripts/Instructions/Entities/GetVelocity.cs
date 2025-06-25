using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Entities {
    public static class GetVelocity {
        public const string Path = "wq";

        #region Docs

        public const string Description = "Transforms an entity on the stack into the direction in which it's moving, with the speed of that movement as that direction's magnitude.";
        public const string Input = "Entity";
        public const string Output = "Vector | Garbage";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, Entity entity) {
            ExecutionState success = entity.GetVelocity(out Vector3 velocity);
            if (!success.IsOk())
                return success;
            info.Stack.Push(new StackItem(velocity));
            return success;
        }
    }
}