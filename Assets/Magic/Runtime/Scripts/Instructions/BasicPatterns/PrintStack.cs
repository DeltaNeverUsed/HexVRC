using BefuddledLabs.Magic.Debug.VUdon;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class PrintStack {
        public const string Path = "de";

        #region Docs

        public const string Description = "Debug.Logs the stack to the console";
        public const string Input = "";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info) {
            StackItem[] wholeStack = info.Stack.ToArray();
            info.VM.Log("Printing stack!");
            
            foreach (StackItem t in wholeStack)
                info.VM.Log("  " + t.ToString());

            return ExecutionState.Ok();
        }
    }
}