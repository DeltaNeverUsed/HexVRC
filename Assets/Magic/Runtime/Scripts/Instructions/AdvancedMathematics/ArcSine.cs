using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.AdvancedMathematics {
    public static class ArcSine {
        public const string Path = "ddeeeee";

        #region Docs

        public const string Description =
            "Takes the inverse sine of a value with absolute value 1 or less, yielding the angle whose sine is that value. Related to the values of π and τ.";

        public const string Input = "Number";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a) {
            info.Stack.Push(new StackItem(Mathf.Asin(a)));
            return ExecutionState.Ok();
        }
    }
}