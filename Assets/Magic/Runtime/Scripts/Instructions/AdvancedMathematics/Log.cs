using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.AdvancedMathematics {
    public static class Log {
        public const string Path = "eqaqe";

        #region Docs

        public const string Description =
            "Removes the number at the top of the stack, then takes the logarithm of the number at the top using the other number as its base. Related to the value of e.";

        public const string Input = "Number, Number";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a, float b) {
            info.Stack.Push(new StackItem(Mathf.Log(a, b)));
            return ExecutionState.Ok();
        }
    }
}