using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.EscapingPatterns {
    public static class Retrospection {
        public const string Path = "eee";

        #region Docs

        public const string Description = "Escapes the introspection";
        public const string Input = "";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            info.VM.IntrospectionDepth = Mathf.Max(0, info.VM.IntrospectionDepth - 1);
            return ExecutionState.Ok();
        }
    }
}