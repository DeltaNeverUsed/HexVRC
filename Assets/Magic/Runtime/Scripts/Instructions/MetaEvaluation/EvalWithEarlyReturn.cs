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


        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> symbols) {
            List<Instruction> instructions = new List<Instruction>(symbols.Count);
            foreach (StackItem item in symbols) {
                if (item.Type == ItemType.Instruction)
                    instructions.Add((Instruction)item.Value);
            }

            List<StackItem> haltInstructionList = new List<StackItem>();
            haltInstructionList.Add(new StackItem(new Instruction(Halt.Path)));
            info.Stack.Push(new StackItem(haltInstructionList));
            ExecutionState success = info.VM.Execute(instructions);
            return success;
        }
    }
}