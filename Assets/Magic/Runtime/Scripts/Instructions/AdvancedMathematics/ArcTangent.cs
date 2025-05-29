using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.AdvancedMathematics {
    public static class ArcTangent {
        public const string Path = "eadeeeeew";

        #region Docs

        public const string Description =
            "Takes the inverse tangent of a value, yielding the angle whose tangent is that value. Related to the values of π and τ.";

        public const string Input = "Number";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a) {
            info.Stack.Push(new StackItem(Mathf.Atan(a)));
            return ExecutionState.Ok();
        }
    }
}