using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.AdvancedMathematics {
    public static class Sine {
        public const string Path = "waawqqqqqaa";

        #region Docs

        public const string Description =
            "Takes the sine of an angle in radians, yielding the vertical component of that angle drawn on a unit circle. Related to the values of π and τ.";

        public const string Input = "Number";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a) {
            info.Stack.Push(new StackItem(Mathf.Sin(a)));
            return ExecutionState.Ok();
        }
    }
}