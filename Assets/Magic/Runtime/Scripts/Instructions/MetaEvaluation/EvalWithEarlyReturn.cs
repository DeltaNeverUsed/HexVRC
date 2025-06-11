using System.Collections.Generic;
using UdonSharp;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.MetaEvaluation {
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
            haltInstructionList.Add(new StackItem(new Instruction(Skip.Path)));
            info.Stack.Push(new StackItem(haltInstructionList));
            
            ListHelpers.InsertList(ref info.VM.CurrentInstructions, instructions, info.CurrentInstructionIndex + 1);
            info.VM.SkipIndexes.Push(info.CurrentInstructionIndex + 1 + instructions.Count);
            return ExecutionState.Ok();
        }
        
        public static ExecutionState Execute(ExecutionInfo info, Instruction symbol) {
            List<StackItem> list = new List<StackItem>();
            list.Add(new StackItem(symbol));
            return Execute(info, list);
        }
    }
}