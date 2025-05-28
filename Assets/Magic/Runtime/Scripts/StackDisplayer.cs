using System.Text;
using TMPro;
using UdonSharp;

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

            for (int index = stack.Length - 1; index >= 0; index--) {
                sb.AppendLine(stack[index].ToString());
            }
            
            stackDisplay.text = sb.ToString();
            if (gameObject.activeInHierarchy)
                SendCustomEventDelayedSeconds(nameof(UpdateLoop), 0.5f);
        }
    }
}