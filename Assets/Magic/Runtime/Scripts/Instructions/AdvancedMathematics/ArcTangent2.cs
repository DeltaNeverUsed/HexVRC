using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.AdvancedMathematics {
    public static class ArcTangent2 {
        public const string Path = "deadeeeeewd";

        #region Docs

        public const string Description =
            "Takes the inverse tangent of a Y and X value, yielding the angle between the X-axis and a line from the origin to that point.";

        public const string Input = "Number, Number";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a, float b) {
            info.Stack.Push(new StackItem(Mathf.Atan2(a, b)));
            return ExecutionState.Ok();
        }
    }
}