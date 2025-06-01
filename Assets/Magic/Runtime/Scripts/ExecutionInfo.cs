using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class ExecutionInfo {
        public readonly PlayerVM VM;
        public Stack<StackItem> Stack;
        public int GlyphId;
        public string Path;
        
        public ExecutionInfo(PlayerVM vm, Stack<StackItem> stack, string path) {
            VM = vm;
            Stack = stack;
            Path = path;
        }

        public Stack<StackItem> ReplaceStack(Stack<StackItem> stack) {
            Stack = stack;
            return VM.ReplaceStack(Stack);
        }
    }
}