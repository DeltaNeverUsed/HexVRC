using System.Collections.Generic;
using System.Text;
using BefuddledLabs.Magic.Debug.VUdon;
using VRC.SDKBase;

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
            if (info.Stack.Count <= 0)
                return ExecutionState.Ok();
            
            object[] wholeStack = info.Stack.ToArray();

            info.VM.Log("Printing stack!");

            foreach (object t in wholeStack) {
                StringBuilder sb = new StringBuilder();
                sb.Append("  ");
                if (!Utilities.IsValid(t)) {
                    sb.Append("Null");
                }
                else if (t.GetType() == typeof(List<object>) || t.GetType() == typeof(List<Instruction>)) {
                    for (int index = 0; index < ((List<object>)t).Count; index++) {
                        object o = ((List<object>)t)[index];
                        if (index != 0)
                            sb.Append(", ");
                        sb.Append(o.ToString());
                    }
                }
                else if (t.GetType() == typeof(VRCPlayerApi)) {
                    sb.Append("VRCPlayer: ");
                    sb.Append('[');
                    sb.Append(((VRCPlayerApi)t).displayName);
                    sb.Append(", ");
                    sb.Append(((VRCPlayerApi)t).playerId);
                    sb.Append(']');
                }
                else {
                    sb.Append(t.ToString());
                }

                info.VM.Log(sb.ToString());
            }

            return ExecutionState.Ok();
        }
    }
}