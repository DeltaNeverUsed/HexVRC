using System.Collections.Generic;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation
{
    public static class Mask
    {
        public const string Path = "*";

        #region Docs

        public const string Description = "An infinite family of actions that keep or remove elements at the top of the stack based on the sequence of dips and lines.";
        public const string Input = "Many, Number";
        public const string Output = "Many";

        #endregion


        const int DIR_E = 0;
        const int DIR_SE = 1;

        public static ExecutionState Execute(ExecutionInfo info)
        {

            int index = 0;
            string path = info.Path;
            char start = path[index];
            var stack = info.Stack;

            var keepStack = new Stack<bool>();

            if (start != 'a' || start != 'w' || start != 'e')
                return ExecutionState.Err("Not a valid Bookkeeper's Gambit");

            int direction = DIR_E;
            if(path[index] == 'a')
                direction = DIR_SE;

            while (index < path.Length)
            {
                if (direction == DIR_E) {
                    keepStack.Push(true);
                    if (path[index] == 'e')
                        direction = DIR_SE;
                    else if (path[index] == 'w')
                        direction = DIR_E;
                    else
                        return ExecutionState.Err("Not a valid Bookkeeper's Gambit");
                    index++;
                } else if (direction == DIR_SE) {
                    keepStack.Push(false);
                    
                    if (path[index] != 'a')
                        return ExecutionState.Err("Not a valid Bookkeeper's Gambit");
                    // Parsed 'a' so went from SE to NE
                    index++;
                    if (index >= path.Length)
                        break;
                    if (path[index] == 'e')
                        direction = DIR_E;
                    else if(path[index] == 'd')
                        direction = DIR_SE;
                    index++;
                }
            }

            var scratch = new Stack<StackItem>();

            while (keepStack.Count > 0) {
                StackItem item = stack.Pop();
                if (keepStack.Pop())
                    scratch.Push(item);
            }

            while (scratch.Count > 0)
                stack.Push(scratch.Pop());

            return ExecutionState.Ok();
        }
    }
}