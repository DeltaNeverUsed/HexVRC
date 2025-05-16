using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class ExpOrVectorProjection
    {
        public const string Path = "wedew";

        #region Docs

        public const string Description = "Perform exponentiation or vector projection";
        public const string Input = "Number | Vector, Number | Vector";
        public const string Output = "Number | Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a, float b) {
            info.Stack.Push(StackItem.CreateStackItem(Mathf.Pow(a, b)));
            return ExecutionState.Ok();
        }
        
        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, Vector3 b) {
            info.Stack.Push(StackItem.CreateStackItem(Vector3.Project(a, b)));
            return ExecutionState.Ok();
        }
    }
}