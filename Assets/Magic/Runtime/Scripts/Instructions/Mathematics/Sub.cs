using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Sub {
        public const string Path = "wddw";

        #region Docs

        public const string Description = "Subtracts two numbers or vectors";
        public const string Input = "Number | Vector, Number | Vector";
        public const string Output = "Number | Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a, float b) {
            info.Stack.Push(new StackItem(a - b));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, float b) {
            info.Stack.Push(new StackItem(new Vector3(a.x - b, a.y - b, a.z - b)));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, Vector3 b) {
            info.Stack.Push(new StackItem(a - b));
            return ExecutionState.Ok();
        }
    }
}