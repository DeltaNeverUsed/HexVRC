using System.Collections.Generic;
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
            if (info.VM.IntrospectionDepth != 0)
                ((List<StackItem>)info.Stack.Peek().Value).Add(new StackItem(new Instruction(Path)));
            return ExecutionState.Ok();
        }
    }
}