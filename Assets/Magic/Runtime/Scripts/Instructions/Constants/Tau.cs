using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Constants {
    public static class Tau {
        public const string Path = "eawae";

        #region Docs

        public const string Description = "Tau";
        public const string Input = "";
        public const string Output = "Number";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(Mathf.PI * 2f);
            return ExecutionState.Ok();
        }
    }
}