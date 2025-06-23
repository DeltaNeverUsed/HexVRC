using System.Text;
using TMPro;
using UdonSharp;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class StackDisplayer : UdonSharpBehaviour {
        public TextMeshProUGUI stackDisplay;
        public VMManager vmManager;
        
        private void OnEnable() {
            SendCustomEventDelayedSeconds(nameof(UpdateLoop), 0.5f);
        }

        public void UpdateLoop() {
            StringBuilder sb = new StringBuilder();
            StackItem[] stack = vmManager.localVM.Info.Stack.ToArray();

            int forLen = Mathf.Min(stack.Length, 32);
            for (int index = 1; index <= forLen; index++) {
                sb.AppendLine(stack[stack.Length - index].ToString());
            }
            
            stackDisplay.text = sb.ToString();
            if (gameObject.activeInHierarchy)
                SendCustomEventDelayedSeconds(nameof(UpdateLoop), 0.5f);
        }
    }
}