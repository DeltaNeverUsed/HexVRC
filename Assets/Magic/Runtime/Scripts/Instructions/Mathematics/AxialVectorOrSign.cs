using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics {
    public static class AxialVectorOrSign {
        public const string Path = "qqqqqaww";

        #region Docs

        public const string Description =
            "For a vector, coerce it to its nearest axial direction, a unit vector. For a number, return the sign of the number; 1 if positive, -1 if negative. In both cases, zero is unaffected.";

        public const string Input = "Number | Vector";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a) {
            switch (a) {
                case < 0:
                    info.Stack.Push(new StackItem(-1));
                    break;
                case > 0:
                    info.Stack.Push(new StackItem(1));
                    break;
                default:
                    info.Stack.Push(new StackItem(0));
                    break;
            }

            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a) {
            float xAbs = Mathf.Abs(a.x);
            float yAbs = Mathf.Abs(a.y);
            float zAbs = Mathf.Abs(a.z);

            if (xAbs >= yAbs && xAbs >= zAbs)
                info.Stack.Push(new StackItem(new Vector3(a.x, 0, 0)));
            else if (yAbs >= xAbs && yAbs >= zAbs)
                info.Stack.Push(new StackItem(new Vector3(0, a.y, 0)));
            else
                info.Stack.Push(new StackItem(new Vector3(0, 0, a.z)));

            return ExecutionState.Ok();
        }
    }
}