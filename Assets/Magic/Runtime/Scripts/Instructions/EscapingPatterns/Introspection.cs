using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.EscapingPatterns {
    public static class Introspection {
        public const string Path = "qqq";

        #region Docs

        public const string Description = "Escapes all symbols until a Retrospection is reached";
        public const string Input = "";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            if (info.VM.IntrospectionDepth == 0)
                info.Stack.Push(new StackItem(new List<StackItem>()));
            else
                ((List<StackItem>)info.Stack.Peek().Value).Add(new StackItem(new Instruction(Path)));
            info.VM.IntrospectionDepth++;
            return ExecutionState.Ok();
        }
    }
}