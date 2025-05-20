
using System;
using System.Collections.Generic;
using System.Text;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class Instruction {
        public readonly string Path;
        public readonly int GlyphId = -1;

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(Path.ToString());
            sb.Append(":\n");
            
            sb.Append("  GlyphId: ");
            sb.Append(GlyphId.ToString());
            
            return sb.ToString();
        }

        public Instruction(string path) {
            Path = path;
        }

        public Instruction(string path, int glyphId) {
            GlyphId = glyphId;
            Path = path;
        }
        
        public ExecutionState Execute(ExecutionInfo info) {
            info.Path = Path;
            info.GlyphId = GlyphId;
            Stack<StackItem> stack = info.Stack;
            int stackSize = stack.Count;
            switch (Path) {
case "eeeeedw":
return BefuddledLabs.Magic.Instructions.Clear.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddqaa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Bury.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aadaadaa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Copy.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (System.Single)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aadaa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Duplicate.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaedd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.DuplicateSecond.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aadadaaw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.DuplicateTwice.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddad":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Move.Execute(info, (System.Single)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aada":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.StackManipulation.MoveCopy.Execute(info, (System.Single)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "a":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Pop.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaawdde":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Rearrange.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddqdd":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.RotateL.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1, (BefuddledLabs.Magic.StackItem)_param_2);
}
// Restore stack if failed
stack.Push(_param_2);
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaeaa":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.RotateR.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1, (BefuddledLabs.Magic.StackItem)_param_2);
}
// Restore stack if failed
stack.Push(_param_2);
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwaeawqaeaqa":
return BefuddledLabs.Magic.Instructions.StackManipulation.StackSize.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aawdd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Swap.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqqqqq":
return BefuddledLabs.Magic.Instructions.ReadingAndWriting.ReadLast.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "deeeee":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.ReadingAndWriting.WriteLast.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "awqqqwaqw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Player.Impulse.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqed":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsInstanceOwner.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsLocal.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsMaster.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqeq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsPlayerGrounded.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsSuspended.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqaaq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsUserInVR.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqqqaq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.Player.IsValid.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqdad":
if (stackSize >= 4) {
StackItem _param_3 = stack.Pop();
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player && _param_1.Type == ItemType.Number && _param_2.Type == ItemType.Number && _param_3.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Player.PlayHapticEventInLeftHand.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value, (System.Single)_param_3.Value);
}
// Restore stack if failed
stack.Push(_param_3);
stack.Push(_param_2);
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqeada":
if (stackSize >= 4) {
StackItem _param_3 = stack.Pop();
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player && _param_1.Type == ItemType.Number && _param_2.Type == ItemType.Number && _param_3.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Player.PlayHapticEventInRightHand.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value, (System.Single)_param_3.Value);
}
// Restore stack if failed
stack.Push(_param_3);
stack.Push(_param_2);
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "waaw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value);
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqqaww":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.AxialVectorOrSign.Execute(info, (UnityEngine.Vector3)_param_0.Value);
}
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.AxialVectorOrSign.Execute(info, (System.Single)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.Ceil.Execute(info, (UnityEngine.Vector3)_param_0.Value);
}
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Ceil.Execute(info, (System.Single)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wdedw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.Div.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Div.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value);
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Div.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wedew":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.ExpOrVectorProjection.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.ExpOrVectorProjection.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ewq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.Floor.Execute(info, (UnityEngine.Vector3)_param_0.Value);
}
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Floor.Execute(info, (System.Single)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wqaqw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (UnityEngine.Vector3)_param_0.Value);
}
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (System.Single)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "addwaad":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.Mod.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Mod.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "waqaw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.Mult.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Mult.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value);
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Mult.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eqqq":
return BefuddledLabs.Magic.Instructions.Mathematics.Random01.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wddw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.Sub.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Sub.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value);
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Sub.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eqqqqq":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number && _param_2.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.VectorConstruct.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value);
}
// Restore stack if failed
stack.Push(_param_2);
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qeeeee":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.VectorDisintegration.Execute(info, (UnityEngine.Vector3)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.IsSomething.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwaeawq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.ListToStack.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqaede":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.ReverseList.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ewdqdwe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.ListManipulation.StackToList.Execute(info, (System.Single)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqaw":
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Escape.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqq":
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Introspection.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eee":
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Retrospection.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeedw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Undo.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "deaqq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Eval.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwaqde":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.EscapingPatterns.EvalWithEarlyReturn.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "None":
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Halt.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqdee":
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Skip.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaq":
return BefuddledLabs.Magic.Instructions.Constants.E.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dedq":
return BefuddledLabs.Magic.Instructions.Constants.False.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "d":
return BefuddledLabs.Magic.Instructions.Constants.Null.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qdwdq":
return BefuddledLabs.Magic.Instructions.Constants.Pi.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eawae":
return BefuddledLabs.Magic.Instructions.Constants.Tau.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqae":
return BefuddledLabs.Magic.Instructions.Constants.True.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqq":
return BefuddledLabs.Magic.Instructions.Constants.VectorZero.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaq":
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetLocalPlayer.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerEyePosition.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dd":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerEyeRotation.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "awq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerHeight.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerLookDirection.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "de":
return BefuddledLabs.Magic.Instructions.BasicPatterns.PrintStack.Execute(info);
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "weaqa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.RaycastPlayer.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wqaawdd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.RaycastPosition.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dwe":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.SetPlayerHeight.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (System.Single)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_1);
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");

            }if (Path.StartsWith("dedd", StringComparison.InvariantCulture)) {return BefuddledLabs.Magic.Instructions.NumberLiterals.NumberLiteralNegative.Execute(info);
}
if (Path.StartsWith("aqaa", StringComparison.InvariantCulture)) {return BefuddledLabs.Magic.Instructions.NumberLiterals.NumberLiteralPositive.Execute(info);
}
if (Path.StartsWith("", StringComparison.InvariantCulture)) {return BefuddledLabs.Magic.Instructions.StackManipulation.Mask.Execute(info);
}

            return ExecutionState.Err("Path was not a valid instruction.");
        }

    }
}
