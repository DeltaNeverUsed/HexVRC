using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Mult {
        public const string Path = "waqaw";

        #region Docs

        public const HexDir Direction = HexDir.SOUTH_EAST;
        public const string Description = "Multiplies two numbers or a number and a vector or performs a dot product if two vectors are provided.";
        public const string Output = "Number | Vector";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, float a, float b) {
            info.Stack.Push(new StackItem(a * b));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, float b)
        {
            info.Stack.Push(new StackItem(new Vector3(a.x * b, a.y * b, a.z * b)));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, float a, Vector3 b)
        {
            return Execute(info, b, a);
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, Vector3 b) {
            info.Stack.Push(new StackItem(Vector3.Dot(a, b)));
            return ExecutionState.Ok();
        }
    }
}