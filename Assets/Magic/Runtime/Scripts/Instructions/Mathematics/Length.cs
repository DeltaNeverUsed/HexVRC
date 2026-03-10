using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Length {
        public const string Path = "wqaqw";

        #region Docs

        public const HexDir Direction = HexDir.NORTH_EAST;
        public const string Description = "Gets the Absolute of a number or the magnitude of a vector or the length of a list or converts a boolean to a number (true = 1, false = 0)";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a) {
            info.Stack.Push(new StackItem(Mathf.Abs(a)));
            return ExecutionState.Ok();
        }
        public static ExecutionState Execute(ExecutionInfo info, Vector3 a) {
            info.Stack.Push(new StackItem(a.magnitude));
            return ExecutionState.Ok();
        }
        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> a) {
            info.Stack.Push(new StackItem(a.Count));
            return ExecutionState.Ok();
        }
        
        public static ExecutionState Execute(ExecutionInfo info, bool a) {
            info.Stack.Push(new StackItem(a ? 1 : 0));
            return ExecutionState.Ok();
        }
    }
}