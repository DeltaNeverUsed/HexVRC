using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class Mask {
        public const string Path = "*";

        #region Docs

        public const string Description =
            @"An infinite family of actions that keep or remove elements at the top of the stack based on the sequence of dips and lines.

Assuming that I draw a Bookkeeper's Gambit pattern left-to-right, the number of iotas the action will require is determined by the horizontal distance covered by the pattern. From deepest in the stack to shallowest, a flat line will keep the iota, whereas a triangle dipping down will remove it.";

        public const string Input = "Many, Number";
        public const string Output = "Many";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info) {
            string path = info.Path;
            if (path.Length <= 0)
                return ExecutionState.Ok(); // technically just going forward once would be valid, but it does nothing
            
            char start = path[0];
            if (start != 'a' && start != 'w' && start != 'e')
                return ExecutionState.Err("Path was not a valid instruction.");

            List<bool> keep = new List<bool>(info.Stack.Count);
            bool wasLastSkip = start == 'a'; // if we go left after the first symbol we skip the first one.
            keep.Add(!wasLastSkip);
            
            for (int i = (wasLastSkip ? 1 : 0); i < path.Length; i++) {
                char c = path[i];
                if (wasLastSkip) {
                    switch (c) {
                        case 'e':
                            wasLastSkip = false;
                            keep.Add(true);
                            break;
                        case 'd': {
                            i++;
                            if (i >= path.Length)
                                return ExecutionState.Err("Mask was invalid, pattern ended in 'd' expected 'a'");
                            c = path[i];
                            if (c == 'a') {
                                keep.Add(false);
                            }
                            else
                                return ExecutionState.Err($"Mask was invalid, pattern expected 'd' but got '{c}'");
                            break;
                        }
                        default:
                            return ExecutionState.Err($"Mask was invalid, pattern expected 'e' or 'd' but got '{c}'");
                    }
                }
                else {
                    switch (c) {
                        case 'w':
                            keep.Add(true);
                            break;
                        case 'e': {
                            i++;
                            if (i >= path.Length)
                                return ExecutionState.Err("Mask was invalid, pattern ended in 'e' expected 'a'");
                            c = path[i];
                            if (c == 'a') {
                                wasLastSkip = true;
                                keep.Add(false);
                            }
                            else
                                return ExecutionState.Err($"Mask was invalid, pattern expected 'a' but got '{c}'");
                            break;
                        }
                        default:
                            return ExecutionState.Err($"Mask was invalid, pattern expected 'w' or 'a' but got '{c}'");
                    }
                }
            }

            Stack<StackItem> stack = info.Stack;
            int stackCount = stack.Count;
            int toGoThrough = Mathf.Min(stackCount, keep.Count);
            StackItem[] currentStack = stack.ToArray();
            stack.Clear();

            for (int i = 0; i < toGoThrough; i++)
                if (keep[i])
                    stack.Push(currentStack[i]);
            
            for (int i = toGoThrough; i < stackCount; i++)
                stack.Push(currentStack[i]);

            return ExecutionState.Ok();
        }
    }
}