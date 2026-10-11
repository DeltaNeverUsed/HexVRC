using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Random01 {
        public const string Path = "eqqq";

        #region Docs

        public const HexDir Direction = HexDir.NORTH_WEST;
        public const string Description = "Random number between 0 and 1";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(new StackItem(Random.value));
            return ExecutionState.Ok();
        }
    }
}