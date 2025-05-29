using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.MetaEvaluation {
    public static class Eval {
        public const string Path = "deaqq";

        #region Docs

        public const string Description = "Evaluates a list of symbols or a singular symbol";
        public const string Input = "[Symbol] | symbol";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> symbols) {
            List<Instruction> instructions = new List<Instruction>(symbols.Count);
            foreach (StackItem item in symbols) {
                if (item.Type == ItemType.Instruction)
                    instructions.Add((Instruction)item.Value);
            }
            
            ExecutionState success = info.VM.Execute(instructions, info);
            return success;
        }
        
        public static ExecutionState Execute(ExecutionInfo info, Instruction symbol) {
            List<StackItem> list = new List<StackItem>();
            list.Add(new StackItem(symbol));
            return Execute(info, list);
        }
    }
}