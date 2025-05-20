using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Mod
    {
        public const string Path = "addwaad";

        #region Docs

        public const string Description = "Takes the modulus of two numbers or vectors";
        public const string Input = "Number | Vector, Number | Vector";
        public const string Output = "Number | Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a, float b) {
            if (b == 0)
                return ExecutionState.Err("Division by zero");

            info.Stack.Push(new StackItem(a % b));
            return ExecutionState.Ok();
        }
        
        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, Vector3 b) {
            if (b.x == 0 || b.y == 0 || b.z == 0)
                return ExecutionState.Err("Division by zero");

            info.Stack.Push(new StackItem(new Vector3(a.x % b.x, a.y % b.y, a.z % b.z)));
            return ExecutionState.Ok();
        }
    }
}