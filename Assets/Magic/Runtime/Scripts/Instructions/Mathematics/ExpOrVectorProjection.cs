using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Mathematics
{
    public static class ExpOrVectorProjection
    {
        public const string Path = "wedew";

        #region Docs

        public const HexDir Direction = HexDir.NORTH_WEST;
        public const string Description = "Perform exponentiation or vector projection";
        public const string Output = "Number | Vector";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float a, float b)
        {
            info.Stack.Push(new StackItem(Mathf.Pow(a, b)));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, float b)
        {
            info.Stack.Push(new StackItem(new Vector3(Mathf.Pow(a.x, b), Mathf.Pow(a.y, b), Mathf.Pow(a.z, b))));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, float a, Vector3 b)
        {
            info.Stack.Push(new StackItem(new Vector3(Mathf.Pow(a, b.x), Mathf.Pow(a, b.y), Mathf.Pow(a, b.z))));
            return ExecutionState.Ok();
        }

        public static ExecutionState Execute(ExecutionInfo info, Vector3 a, Vector3 b)
        {
            info.Stack.Push(new StackItem(Vector3.Project(a, b)));
            return ExecutionState.Ok();
        }
    }
}