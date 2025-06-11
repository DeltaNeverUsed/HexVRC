using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.MetaEvaluation {
    public static class Map {
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

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> symbols, List<StackItem> items) {
            List<Instruction> instructionsPerItem = new List<Instruction>(symbols.Count + 4);
            instructionsPerItem.Add(new Instruction(AddItemToStack.Path));
            foreach (StackItem item in symbols) {
                if (item.Type == ItemType.Instruction)
                    instructionsPerItem.Add((Instruction)item.Value);
            }
            instructionsPerItem.Add(new Instruction(RestoreStackWithRemainingInList.Path));
            instructionsPerItem.Add(new Instruction(SaveStack.Path));
            instructionsPerItem.Add(new Instruction(StackManipulation.Pop.Path));

            Instruction[] perItemInstructions = instructionsPerItem.ToArray();
            Instruction[] instructionsToInsert = new Instruction[instructionsPerItem.Count * items.Count + 4];
            instructionsToInsert[0] = new Instruction(ListManipulation.CreateList.Path); // create a list to put the stuff in
            instructionsToInsert[1] = new Instruction(SaveStack.Path);
            instructionsToInsert[2] = new Instruction(StackManipulation.Pop.Path);
            instructionsToInsert[instructionsToInsert.Length - 1] = new Instruction(RestoreStack.Path);

            for (int i = 0; i < items.Count; i++) {
                int start = i * instructionsPerItem.Count;
                perItemInstructions[0] = new Instruction(AddItemToStack.Path, items[i]); // replace the data with the item from the items list
                Array.Copy(perItemInstructions, 0, instructionsToInsert, start + 3,
                    perItemInstructions.Length);
                info.VM.SkipIndexes.Push(info.CurrentInstructionIndex + instructionsToInsert.Length - start);
            }
            ListHelpers.InsertList(ref info.VM.CurrentInstructions, new List<Instruction>(instructionsToInsert), info.VM.CurrentInstructions.Count);
            return ExecutionState.Ok();
        }
    }
}