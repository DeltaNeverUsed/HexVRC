using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.NumberLiterals {
    public static class NumberLiteralPositive {
        public const string Path = "aqaa*";

        #region Docs
        
        public const string Description = "Adds a positive Number to the stack";
        public const string Input = "";
        public const string Output = "Number";

        #endregion

        public static float PathToNumber(string path) {
            string numberPath = path.Substring(4);

            float number = 0f;

            foreach (char direction in numberPath) {
                switch (direction)
                {
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
            info.Stack.Push(StackItem.CreateStackItem(PathToNumber(info.Path)));

            return ExecutionState.Ok();
        }
    }
}