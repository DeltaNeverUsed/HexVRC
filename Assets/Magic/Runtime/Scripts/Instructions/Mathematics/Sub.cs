using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class Sub {
        public const string Path = "wddw";

        #region Docs

        public const HexDir Direction = HexDir.NORTH_WEST;
        public const string Description = "Subtracts two numbers or vectors";
        public const string Output = "Number | Vector";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, float a, float b) {
            info.Stack.Push(new StackItem(a - b));
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
            info.Stack.Push(new StackItem(a - b));
            return ExecutionState.Ok();
        }
    }
}