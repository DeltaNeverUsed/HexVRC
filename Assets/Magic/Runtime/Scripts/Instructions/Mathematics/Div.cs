using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Div {
        public const string Path = "wdedw";

        #region Docs

        public const string Description = "Divides two numbers or vectors";
        public const string Input = "Number | Vector, Number | Vector";
        public const string Output = "Number | Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a, float b) {
            if (b == 0)
                return ExecutionState.Err("Division by zero");

            info.Stack.Push(a / b);
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, float b) {
            if (b == 0)
                return ExecutionState.Err("Division by zero");

            info.Stack.Push(new Vector3(a.x / b, a.y / b, a.z / b));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, Vector3 b) {
            info.Stack.Push(Vector3.Cross(a, b));
            return ExecutionState.Ok();
        }
    }
}