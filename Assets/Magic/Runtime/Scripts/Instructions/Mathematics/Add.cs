using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Add {
        public const string Path = "waaw";

        #region Docs

        public const HexDir Direction = HexDir.NORTH_EAST;
        public const string Description = "Adds two numbers or vectors together or combines two lists";
        public const string Output = "Number | Vector | List";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, float a, float b) {
            info.Stack.Push(new StackItem(a + b));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, float b)
        {
            return Execute(info, a, new Vector3(b, b, b));
        }

        public static ExecutionState Execute(ExecutionInfo info, float a, Vector3 b)
        {
            return Execute(info, new Vector3(a, a, a), b);
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, Vector3 b) {
            info.Stack.Push(new StackItem(a + b));
            return ExecutionState.Ok();
        }
        
        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> l1, List<StackItem> l2) {
            foreach (StackItem item in l2)
                l1.Add(item);
            info.Stack.Push(new StackItem(l1));
            return ExecutionState.Ok();
        }
    }
}