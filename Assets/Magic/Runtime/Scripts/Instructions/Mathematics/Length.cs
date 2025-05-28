using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Length {
        public const string Path = "wqaqw";

        #region Docs

        public const string Description = "Gets the Absolute of a number or the Length of a Vector or List";
        public const string Input = "Number | Vector";
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
    }
}