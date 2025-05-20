using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class VectorConstruct {
        public const string Path = "eqqqqq";

        #region Docs

        public const string Description = "Creates a vector from 3 numbers(x, y, z)";
        public const string Input = "Number, Number, Number";
        public const string Output = "Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float x, float y, float z) {
            info.Stack.Push(new StackItem(new Vector3(x, y, z)));
            return ExecutionState.Ok();
        }
    }
}