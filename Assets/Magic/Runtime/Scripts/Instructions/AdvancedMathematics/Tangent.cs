using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.AdvancedMathematics {
    public static class Tangent {
        public const string Path = "wqqqqqadq";

        #region Docs

        public const string Description =
            "Takes the tangent of an angle in radians, yielding the slope of that angle drawn on a circle. Related to the values of π and τ.";

        public const string Input = "Number";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a) {
            info.Stack.Push(new StackItem(Mathf.Tan(a)));
            return ExecutionState.Ok();
        }
    }
}