using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.AdvancedMathematics {
    public static class ArcCosine {
        public const string Path = "adeeeee";

        #region Docs

        public const string Description =
            "Takes the inverse cosine of a value with absolute value 1 or less, yielding the angle whose cosine is that value. Related to the values of π and τ.";

        public const string Input = "Number";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a) {
            info.Stack.Push(new StackItem(Mathf.Acos(a)));
            return ExecutionState.Ok();
        }
    }
}