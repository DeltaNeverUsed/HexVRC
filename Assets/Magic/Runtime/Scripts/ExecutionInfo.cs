using System.Collections.Generic;

namespace BefuddledLabs.Magic {
    public class ExecutionInfo {
        public readonly PlayerVM VM;
        public readonly Stack<StackItem> Stack;
        public string Path;
        
        public ExecutionInfo(PlayerVM vm, Stack<StackItem> stack, string path) {
            VM = vm;
            Stack = stack;
            Path = path;
        }
    }
}