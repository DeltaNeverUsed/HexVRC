
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
case "ddqaa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Bury.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
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
stack.Push(_param_0);
stack.Push(_param_1);
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
stack.Push(_param_0);
stack.Push(_param_1);
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
stack.Push(_param_0);
stack.Push(_param_1);
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
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
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
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwaeawqaeaqa":
ExecutionState __result_StackSize_0 = BefuddledLabs.Magic.Instructions.StackManipulation.StackSize.Execute(info);
if (!__result_StackSize_0.Success) {
// Restore stack if execution failed
}
return __result_StackSize_0;
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
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqqqqq":
ExecutionState __result_ReadLast_0 = BefuddledLabs.Magic.Instructions.ReadingAndWriting.ReadLast.Execute(info);
if (!__result_ReadLast_0.Success) {
// Restore stack if execution failed
}
return __result_ReadLast_0;
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
stack.Push(_param_0);
stack.Push(_param_1);
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
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
stack.Push(_param_3);
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
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
stack.Push(_param_3);
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
stack.Push(_param_0);
stack.Push(_param_1);
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
stack.Push(_param_0);
stack.Push(_param_1);
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
stack.Push(_param_0);
stack.Push(_param_1);
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
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
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
stack.Push(_param_0);
stack.Push(_param_1);
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
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eqqq":
ExecutionState __result_Random01_0 = BefuddledLabs.Magic.Instructions.Mathematics.Random01.Execute(info);
if (!__result_Random01_0.Success) {
// Restore stack if execution failed
}
return __result_Random01_0;
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
stack.Push(_param_0);
stack.Push(_param_1);
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
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
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
case "waaww":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.Concat.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqaeaae":
ExecutionState __result_CreateList_0 = BefuddledLabs.Magic.Instructions.ListManipulation.CreateList.Execute(info);
if (!__result_CreateList_0.Success) {
// Restore stack if execution failed
}
return __result_CreateList_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "adeeed":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.CreateListFromAny.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "deeed":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.ListManipulation.GetIndex.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaeaqwded":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.Number && _param_2.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.ListManipulation.GetSlice.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value);
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dedqde":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.IndexOf.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1);
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
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
case "qaeaq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.Pop.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "edqde":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.Push.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1);
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "edqdewaqa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.ListManipulation.RemoveAt.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value);
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
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
ExecutionState __result_Escape_0 = BefuddledLabs.Magic.Instructions.EscapingPatterns.Escape.Execute(info);
if (!__result_Escape_0.Success) {
// Restore stack if execution failed
}
return __result_Escape_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqq":
ExecutionState __result_Introspection_0 = BefuddledLabs.Magic.Instructions.EscapingPatterns.Introspection.Execute(info);
if (!__result_Introspection_0.Success) {
// Restore stack if execution failed
}
return __result_Introspection_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eee":
ExecutionState __result_Retrospection_0 = BefuddledLabs.Magic.Instructions.EscapingPatterns.Retrospection.Execute(info);
if (!__result_Retrospection_0.Success) {
// Restore stack if execution failed
}
return __result_Retrospection_0;
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
ExecutionState __result_Halt_0 = BefuddledLabs.Magic.Instructions.EscapingPatterns.Halt.Execute(info);
if (!__result_Halt_0.Success) {
// Restore stack if execution failed
}
return __result_Halt_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqdee":
ExecutionState __result_Skip_0 = BefuddledLabs.Magic.Instructions.EscapingPatterns.Skip.Execute(info);
if (!__result_Skip_0.Success) {
// Restore stack if execution failed
}
return __result_Skip_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaq":
ExecutionState __result_E_0 = BefuddledLabs.Magic.Instructions.Constants.E.Execute(info);
if (!__result_E_0.Success) {
// Restore stack if execution failed
}
return __result_E_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dedq":
ExecutionState __result_False_0 = BefuddledLabs.Magic.Instructions.Constants.False.Execute(info);
if (!__result_False_0.Success) {
// Restore stack if execution failed
}
return __result_False_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "d":
ExecutionState __result_Null_0 = BefuddledLabs.Magic.Instructions.Constants.Null.Execute(info);
if (!__result_Null_0.Success) {
// Restore stack if execution failed
}
return __result_Null_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qdwdq":
ExecutionState __result_Pi_0 = BefuddledLabs.Magic.Instructions.Constants.Pi.Execute(info);
if (!__result_Pi_0.Success) {
// Restore stack if execution failed
}
return __result_Pi_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eawae":
ExecutionState __result_Tau_0 = BefuddledLabs.Magic.Instructions.Constants.Tau.Execute(info);
if (!__result_Tau_0.Success) {
// Restore stack if execution failed
}
return __result_Tau_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqae":
ExecutionState __result_True_0 = BefuddledLabs.Magic.Instructions.Constants.True.Execute(info);
if (!__result_True_0.Success) {
// Restore stack if execution failed
}
return __result_True_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqq":
ExecutionState __result_VectorZero_0 = BefuddledLabs.Magic.Instructions.Constants.VectorZero.Execute(info);
if (!__result_VectorZero_0.Success) {
// Restore stack if execution failed
}
return __result_VectorZero_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeedw":
ExecutionState __result_Clear_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.Clear.Execute(info);
if (!__result_Clear_0.Success) {
// Restore stack if execution failed
}
return __result_Clear_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaq":
ExecutionState __result_GetLocalPlayer_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.GetLocalPlayer.Execute(info);
if (!__result_GetLocalPlayer_0.Success) {
// Restore stack if execution failed
}
return __result_GetLocalPlayer_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeawa":
ExecutionState __result_GetPickupDirection_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.GetPickupDirection.Execute(info);
if (!__result_GetPickupDirection_0.Success) {
// Restore stack if execution failed
}
return __result_GetPickupDirection_0;
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeaa":
ExecutionState __result_GetPickupPosition_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.GetPickupPosition.Execute(info);
if (!__result_GetPickupPosition_0.Success) {
// Restore stack if execution failed
}
return __result_GetPickupPosition_0;
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
ExecutionState __result_PrintStack_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.PrintStack.Execute(info);
if (!__result_PrintStack_0.Success) {
// Restore stack if execution failed
}
return __result_PrintStack_0;
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
stack.Push(_param_0);
stack.Push(_param_1);
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
stack.Push(_param_0);
stack.Push(_param_1);
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
stack.Push(_param_0);
stack.Push(_param_1);
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
