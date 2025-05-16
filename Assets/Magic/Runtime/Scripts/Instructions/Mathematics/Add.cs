using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Add {
        public const string Path = "waaw";

        #region Docs

        public const string Description = "Adds two numbers or vectors together";
        public const string Input = "Number | Vector, Number | Vector";
        public const string Output = "Number | Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a, float b) {
            info.Stack.Push(StackItem.CreateStackItem(a + b));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, float b) {
            info.Stack.Push(StackItem.CreateStackItem(new Vector3(a.x + b, a.y + b, a.z + b)));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, Vector3 b) {
            info.Stack.Push(StackItem.CreateStackItem(a + b));
            return ExecutionState.Ok();
        }
    }
}