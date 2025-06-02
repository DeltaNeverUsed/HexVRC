// ReSharper disable once CheckNamespace

namespace BefuddledLabs.Magic.Instructions.NumberLiterals {
    public static class NumberLiteralPositive {
        public const string Path = "aqaa*";

        #region Docs

        public const string Description = @"Irritatingly, there is no easy way to draw numbers. Here is the method Nature deigned to give us.

First, I draw one of the two shapes shown on the other page. Next, the angles following will modify a running count starting at 0.

Forward: Add 1

Left: Add 5

Right: Add 10

Sharp Left: Multiply by 2

Sharp Right: Divide by 2.
The clockwise version of the pattern, on the right of the other page, will negate the value at the very end. (The left-hand counter-clockwise version keeps the number positive).

Once I finish drawing, the number's pushed to the top of the stack.
";
        public const string Input = "";
        public const string Output = "Number";

        #endregion

        public static float PathToNumber(string path) {
            string numberPath = path.Substring(4);

            float number = 0f;

            foreach (char direction in numberPath) {
                switch (direction) {
                    case 'a':
                        number *= 2f;
                        break;
                    case 'q':
                        number += 5f;
                        break;
                    case 'w':
                        number++;
                        break;
                    case 'e':
                        number += 10f;
                        break;
                    case 'd':
                        number /= 2f;
                        break;
                }
            }

            return number;
        }

        public static ExecutionState Execute(ExecutionInfo info) {
            info.Stack.Push(new StackItem(PathToNumber(info.Path)));

            return ExecutionState.Ok();
        }
    }
}