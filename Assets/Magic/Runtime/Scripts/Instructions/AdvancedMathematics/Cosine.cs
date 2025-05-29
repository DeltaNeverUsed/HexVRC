using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.AdvancedMathematics {
    public static class Cosine {
        public const string Path = "qqqqqad";

        #region Docs

        public const string Description =
            "Takes the cosine of an angle in radians, yielding the horizontal component of that angle drawn on a unit circle. Related to the values of π and τ.";

        public const string Input = "Number";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a) {
            info.Stack.Push(new StackItem(Mathf.Cos(a)));
            return ExecutionState.Ok();
        }
    }
}