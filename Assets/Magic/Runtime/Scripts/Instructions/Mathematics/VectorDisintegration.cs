using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class VectorDisintegration {
        public const string Path = "qeeeee";

        #region Docs

        public const string Description = "Disintegrates a Vector into it's components";
        public const string Input = "Vector";
        public const string Output = "Number, Number, Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, Vector3 vec) {
            info.Stack.Push(new StackItem(vec.x));
            info.Stack.Push(new StackItem(vec.y));
            info.Stack.Push(new StackItem(vec.z));
            return ExecutionState.Ok();
        }
    }
}