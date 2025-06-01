using System.Collections.Generic;
using UdonSharp;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.MetaEvaluation {
    public static class ForEach {
        public const string Path = "dadad";

        #region Docs

        public const string Description =
            @"Remove a list of patterns and a list from the stack, then cast the given pattern over each element of the second list.

More specifically, for each element in the second list, it will:

Create a new stack, with everything on the current stack plus that element

Draw all the patterns in the first list

Save all the iotas remaining on the stack to a list
Then, after all is said and done, pushes the list of saved iotas onto the main stack.";

        public const string Input = "[Symbol], List";
        public const string Output = "List";

        #endregion

        [RecursiveMethod]
        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> symbols, List<StackItem> items) {
            List<Instruction> instructions = new List<Instruction>(symbols.Count);
            foreach (StackItem item in symbols) {
                if (item.Type == ItemType.Instruction)
                    instructions.Add((Instruction)item.Value);
            }

            Stack<StackItem> stackToRestore = info.Stack;
            StackItem[] oldStackItems = stackToRestore.ToArray();
            List<StackItem> returns = new List<StackItem>();
            foreach (StackItem item in items) {
                Stack<StackItem> newStack = new Stack<StackItem>();
                info.ReplaceStack(newStack);
                foreach (StackItem stackItem in oldStackItems)
                    newStack.Push(stackItem);
                
                info.Stack.Push(item);
                ExecutionState success = info.VM.Execute(instructions, info);
                if (success.IsOk()) {
                    StackItem[] stackArray = info.Stack.ToArray();
                    foreach (StackItem returnItem in stackArray) {
                        returns.Add(returnItem);
                    }
                }
                else {
                    stackToRestore.Push(new StackItem(returns));
                    info.ReplaceStack(stackToRestore);
                    return ExecutionState.Err("ForEach Failed with: " + success.Error);
                }
            }
            
            stackToRestore.Push(new StackItem(returns));
            info.ReplaceStack(stackToRestore);
            return ExecutionState.Ok();
        }
    }
}