
using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class Instruction {
        public readonly string Path;
        public readonly int SymbolIndex = -1;

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(Path.ToString());
            sb.Append(":\n");
            
            sb.Append("  SymbolIndex: ");
            sb.Append(SymbolIndex.ToString());
            
            return sb.ToString();
        }

        public Instruction(string path) {
            Path = path;
        }

        public Instruction(string path, int symbolIndex) {
            SymbolIndex = symbolIndex;
            Path = path;
        }
        
        public ExecutionState Execute(ExecutionInfo info) {
            int stackSize = info.Stack.Count;
            

            return ExecutionState.Err("Path was not a valid instruction.");
        }

    }
}
