using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.EscapingPatterns {
    public static class Eval {
        public const string Path = "deaqq";

        #region Docs

        public const string Description = "Evaluates a list of symbols or a singular symbol";
        public const string Input = "[Symbol] | symbol";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, List<Instruction> symbols) {
            ExecutionState success = info.VM.Execute(symbols);
            return success;
        }
    }
}