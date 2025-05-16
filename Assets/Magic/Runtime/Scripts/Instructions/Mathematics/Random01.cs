using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Random01
    {
        public const string Path = "eqqq";

        #region Docs

        public const string Description = "Random number between 0 and 1";
        public const string Input = "";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(StackItem.CreateStackItem(Random.value));
            return ExecutionState.Ok();
        }
    }
}