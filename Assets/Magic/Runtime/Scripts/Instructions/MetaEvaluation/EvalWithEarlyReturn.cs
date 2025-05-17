using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.EscapingPatterns {
    public static class EvalWithEarlyReturn {
        public const string Path = "qwaqde";

        #region Docs

        public const string Description =
            "Evaluates a list of symbols or a singular symbol, but adds a special skip instruction to the stack, that when executed will skip the rest of the patterns in the pattern list";

        public const string Input = "[Symbol] | symbol";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, List<Instruction> symbols) {
            List<Instruction> haltInstructionList = new List<Instruction>();
            haltInstructionList.Add(new Instruction(Halt.Path));
            info.Stack.Push(haltInstructionList);
            ExecutionState success = info.VM.Execute(symbols);
            return success;
        }
    }
}