using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Ceil
    {
        public const string Path = "qwe";

        #region Docs

        public const string Description = "Ceils a number or vector";
        public const string Input = "Number | Vector";
        public const string Output = "Number | Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a) {
            info.Stack.Push(new StackItem(Mathf.Ceil(a)));
            return ExecutionState.Ok();
        }
        
        public static ExecutionState Execute(ExecutionInfo info, Vector3 a) {
            info.Stack.Push(new StackItem(new Vector3(Mathf.Ceil(a.x), Mathf.Ceil(a.y), Mathf.Ceil(a.z))));
            return ExecutionState.Ok();
        }
    }
}