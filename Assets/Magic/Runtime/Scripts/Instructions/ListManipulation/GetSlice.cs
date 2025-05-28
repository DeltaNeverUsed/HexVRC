using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.ListManipulation {
    public static class GetSlice {
        public const string Path = "qaeaqwded";

        #region Docs

        public const string Description =
            "Remove the two numbers at the top of the stack, then take a sublist of the list at the top of the stack between those indices, lower bound inclusive, upper bound exclusive. For example, the 0, 2 sublist of [0, 1, 2, 3, 4] would be [0, 1].";

        public const string Input = "List, Number, Number";
        public const string Output = "List";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> stackItems, float startFloat, float endFloat) {
            int start = Mathf.RoundToInt(startFloat);
            int end = Mathf.RoundToInt(Mathf.Min(endFloat, stackItems.Count-1));
            int count = start - end;
            
            switch (count) {
                case < 0:
                    return ExecutionState.Err("End cannot be before start.");
                case 0:
                    info.Stack.Push(new StackItem(new List<StackItem>()));
                    return ExecutionState.Ok();
                default:
                    List<StackItem> newStackItems = new List<StackItem>();
                    for (int i = 0; i < count; i++)
                        newStackItems.Add(stackItems[i + start]);
                    
                    info.Stack.Push(new StackItem(newStackItems));
                    return ExecutionState.Ok();
            }
        }
    }
}