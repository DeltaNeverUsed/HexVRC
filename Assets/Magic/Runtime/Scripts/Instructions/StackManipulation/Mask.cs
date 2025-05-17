using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class Mask {
        public const string Path = "*";

        #region Docs

        public const string Description =
            "An infinite family of actions that keep or remove elements at the top of the stack based on the sequence of dips and lines.";

        public const string Input = "Many, Number";
        public const string Output = "Many";

        #endregion


        private const int DirE = 0;
        private const int DirSe = 1;

        public static ExecutionState Execute(ExecutionInfo info) {
            int index = 0;
            
            
            string path = info.Path;
            if (path.Length > index)
                return ExecutionState.Err("Not a valid Bookkeeper's Gambit");
            
            char start = path[index];

            if (start != 'a' || start != 'w' || start != 'e')
                return ExecutionState.Err("Not a valid Bookkeeper's Gambit");

            Stack<object> stack = info.Stack;
            Stack<bool> keepStack = new Stack<bool>();
            int direction = DirE;
            if (path[index] == 'a')
                direction = DirSe;

            while (index < path.Length) {
                if (direction == DirE) {
                    keepStack.Push(true);
                    if (path[index] == 'e')
                        direction = DirSe;
                    else if (path[index] == 'w')
                        direction = DirE;
                    else
                        return ExecutionState.Err("Not a valid Bookkeeper's Gambit");
                    index++;
                }
                else if (direction == DirSe) {
                    keepStack.Push(false);

                    if (path[index] != 'a')
                        return ExecutionState.Err("Not a valid Bookkeeper's Gambit");
                    // Parsed 'a' so went from SE to NE
                    index++;
                    if (index >= path.Length)
                        break;
                    if (path[index] == 'e')
                        direction = DirE;
                    else if (path[index] == 'd')
                        direction = DirSe;
                    index++;
                }
            }

            Stack<object> scratch = new Stack<object>();

            while (keepStack.Count > 0) {
                object item = stack.Pop();
                if (keepStack.Pop())
                    scratch.Push(item);
            }

            while (scratch.Count > 0)
                stack.Push(scratch.Pop());

            return ExecutionState.Ok();
        }
    }
}