using System;
using System.Collections.Generic;
using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using Varneon.VUdon.Logger;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class NotationRunner : UdonSharpBehaviour {
        public VMManager vm;
        
        public string[] notationInstructions = Array.Empty<string>();
        public UdonConsole _console;

        public override void Interact() {
            if (!Utilities.IsValid(vm) || !Utilities.IsValid(vm.localVM))
                return;
            
            List<Instruction> instructions = new List<Instruction>();

            foreach (string t in notationInstructions) {
                this.Log($"Parsed: {t}");
                
                instructions.Add(new Instruction(t));
            }
            
            ExecutionState success = vm.localVM.Execute(instructions);
            
            this.Log("Executed finished with success of " + success.ToString());
        }
    }
}