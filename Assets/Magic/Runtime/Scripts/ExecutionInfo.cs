using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class ExecutionInfo {
        public readonly PlayerVM VM;
        public readonly Stack<object> Stack;
        public int GlyphId;
        public string Path;
        
        public ExecutionInfo(PlayerVM vm, Stack<object> stack, string path) {
            VM = vm;
            Stack = stack;
            Path = path;
        }
    }
}