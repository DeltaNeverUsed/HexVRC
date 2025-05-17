using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.EscapingPatterns {
    public static class Undo {
        public const string Path = "eeedw";

        #region Docs

        public const string Description = "Removes the last Symbol from the Symbol list";
        public const string Input = "";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, List<Instruction> patterns) {
            patterns.RemoveAt(patterns.Count - 1);
            return ExecutionState.Ok();
        }
    }
}