using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Floor
    {
        public const string Path = "ewq";

        #region Docs

        public const string Description = "Floors a number or vector";
        public const string Input = "Number | Vector";
        public const string Output = "Number | Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a) {
            info.Stack.Push(StackItem.CreateStackItem(Mathf.Floor(a)));
            return ExecutionState.Ok();
        }
        
        public static ExecutionState Execute(ExecutionInfo info, Vector3 a) {
            info.Stack.Push(StackItem.CreateStackItem(new Vector3(Mathf.Floor(a.x), Mathf.Floor(a.y), Mathf.Floor(a.z))));
            return ExecutionState.Ok();
        }
    }
}