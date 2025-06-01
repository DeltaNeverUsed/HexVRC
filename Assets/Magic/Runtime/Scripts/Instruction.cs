
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
ExecutionState __result_Bury_0 = BefuddledLabs.Magic.Instructions.StackManipulation.Bury.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
if (!__result_Bury_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Bury_0;
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
ExecutionState __result_Copy_0 = BefuddledLabs.Magic.Instructions.StackManipulation.Copy.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (System.Single)_param_1.Value);
if (!__result_Copy_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Copy_0;
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
ExecutionState __result_Duplicate_0 = BefuddledLabs.Magic.Instructions.StackManipulation.Duplicate.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
if (!__result_Duplicate_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Duplicate_0;
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
ExecutionState __result_DuplicateSecond_0 = BefuddledLabs.Magic.Instructions.StackManipulation.DuplicateSecond.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
if (!__result_DuplicateSecond_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_DuplicateSecond_0;
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
ExecutionState __result_DuplicateTwice_0 = BefuddledLabs.Magic.Instructions.StackManipulation.DuplicateTwice.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
if (!__result_DuplicateTwice_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_DuplicateTwice_0;
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
ExecutionState __result_Move_0 = BefuddledLabs.Magic.Instructions.StackManipulation.Move.Execute(info, (System.Single)_param_0.Value);
if (!__result_Move_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Move_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aada":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_MoveCopy_0 = BefuddledLabs.Magic.Instructions.StackManipulation.MoveCopy.Execute(info, (System.Single)_param_0.Value);
if (!__result_MoveCopy_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_MoveCopy_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "a":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
ExecutionState __result_Pop_0 = BefuddledLabs.Magic.Instructions.StackManipulation.Pop.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
if (!__result_Pop_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Pop_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaawdde":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
ExecutionState __result_Rearrange_0 = BefuddledLabs.Magic.Instructions.StackManipulation.Rearrange.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
if (!__result_Rearrange_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Rearrange_0;
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
ExecutionState __result_RotateL_0 = BefuddledLabs.Magic.Instructions.StackManipulation.RotateL.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1, (BefuddledLabs.Magic.StackItem)_param_2);
if (!__result_RotateL_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
}
return __result_RotateL_0;
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
ExecutionState __result_RotateR_0 = BefuddledLabs.Magic.Instructions.StackManipulation.RotateR.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1, (BefuddledLabs.Magic.StackItem)_param_2);
if (!__result_RotateR_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
}
return __result_RotateR_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwaeawqaeaqa":
{
ExecutionState __result_StackSize_0 = BefuddledLabs.Magic.Instructions.StackManipulation.StackSize.Execute(info);
if (!__result_StackSize_0.Success) {
// Restore stack if execution failed
}
return __result_StackSize_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aawdd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
ExecutionState __result_Swap_0 = BefuddledLabs.Magic.Instructions.StackManipulation.Swap.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
if (!__result_Swap_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Swap_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aweaqa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
ExecutionState __result_Deduplicate_0 = BefuddledLabs.Magic.Instructions.Sets.Deduplicate.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
if (!__result_Deduplicate_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Deduplicate_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqqqqq":
{
ExecutionState __result_ReadLast_0 = BefuddledLabs.Magic.Instructions.ReadingAndWriting.ReadLast.Execute(info);
if (!__result_ReadLast_0.Success) {
// Restore stack if execution failed
}
return __result_ReadLast_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "deeeee":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
ExecutionState __result_WriteLast_0 = BefuddledLabs.Magic.Instructions.ReadingAndWriting.WriteLast.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
if (!__result_WriteLast_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_WriteLast_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "awqqqwaqw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone && _param_1.Type == ItemType.Vector) {
ExecutionState __result_Impulse_1 = BefuddledLabs.Magic.Instructions.Player.Impulse.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
if (!__result_Impulse_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Impulse_1;
}
if (_param_0.Type == ItemType.Player && _param_1.Type == ItemType.Vector) {
ExecutionState __result_Impulse_0 = BefuddledLabs.Magic.Instructions.Player.Impulse.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
if (!__result_Impulse_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Impulse_0;
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
ExecutionState __result_IsInstanceOwner_0 = BefuddledLabs.Magic.Instructions.Player.IsInstanceOwner.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
if (!__result_IsInstanceOwner_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_IsInstanceOwner_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
ExecutionState __result_IsLocal_0 = BefuddledLabs.Magic.Instructions.Player.IsLocal.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
if (!__result_IsLocal_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_IsLocal_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
ExecutionState __result_IsMaster_0 = BefuddledLabs.Magic.Instructions.Player.IsMaster.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
if (!__result_IsMaster_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_IsMaster_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqeq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
ExecutionState __result_IsPlayerGrounded_0 = BefuddledLabs.Magic.Instructions.Player.IsPlayerGrounded.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
if (!__result_IsPlayerGrounded_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_IsPlayerGrounded_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
ExecutionState __result_IsSuspended_0 = BefuddledLabs.Magic.Instructions.Player.IsSuspended.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
if (!__result_IsSuspended_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_IsSuspended_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqaaq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
ExecutionState __result_IsUserInVR_0 = BefuddledLabs.Magic.Instructions.Player.IsUserInVR.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
if (!__result_IsUserInVR_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_IsUserInVR_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqqqaq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
ExecutionState __result_IsValid_0 = BefuddledLabs.Magic.Instructions.Player.IsValid.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
if (!__result_IsValid_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_IsValid_0;
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
ExecutionState __result_PlayHapticEventInLeftHand_0 = BefuddledLabs.Magic.Instructions.Player.PlayHapticEventInLeftHand.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value, (System.Single)_param_3.Value);
if (!__result_PlayHapticEventInLeftHand_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
stack.Push(_param_3);
}
return __result_PlayHapticEventInLeftHand_0;
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
ExecutionState __result_PlayHapticEventInRightHand_0 = BefuddledLabs.Magic.Instructions.Player.PlayHapticEventInRightHand.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value, (System.Single)_param_3.Value);
if (!__result_PlayHapticEventInRightHand_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
stack.Push(_param_3);
}
return __result_PlayHapticEventInRightHand_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
stack.Push(_param_3);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "deaqq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Instruction) {
ExecutionState __result_Eval_1 = BefuddledLabs.Magic.Instructions.MetaEvaluation.Eval.Execute(info, (BefuddledLabs.Magic.Instruction)_param_0.Value);
if (!__result_Eval_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Eval_1;
}
if (_param_0.Type == ItemType.List) {
ExecutionState __result_Eval_0 = BefuddledLabs.Magic.Instructions.MetaEvaluation.Eval.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
if (!__result_Eval_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Eval_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwaqde":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Instruction) {
ExecutionState __result_EvalWithEarlyReturn_1 = BefuddledLabs.Magic.Instructions.MetaEvaluation.EvalWithEarlyReturn.Execute(info, (BefuddledLabs.Magic.Instruction)_param_0.Value);
if (!__result_EvalWithEarlyReturn_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_EvalWithEarlyReturn_1;
}
if (_param_0.Type == ItemType.List) {
ExecutionState __result_EvalWithEarlyReturn_0 = BefuddledLabs.Magic.Instructions.MetaEvaluation.EvalWithEarlyReturn.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
if (!__result_EvalWithEarlyReturn_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_EvalWithEarlyReturn_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dadad":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.List) {
ExecutionState __result_ForEach_0 = BefuddledLabs.Magic.Instructions.MetaEvaluation.ForEach.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_1.Value);
if (!__result_ForEach_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_ForEach_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "None":
{
ExecutionState __result_Halt_0 = BefuddledLabs.Magic.Instructions.MetaEvaluation.Halt.Execute(info);
if (!__result_Halt_0.Success) {
// Restore stack if execution failed
}
return __result_Halt_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqdee":
{
ExecutionState __result_Skip_0 = BefuddledLabs.Magic.Instructions.MetaEvaluation.Skip.Execute(info);
if (!__result_Skip_0.Success) {
// Restore stack if execution failed
}
return __result_Skip_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "waaw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.List) {
ExecutionState __result_Add_3 = BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_1.Value);
if (!__result_Add_3.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Add_3;
}
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
ExecutionState __result_Add_2 = BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
if (!__result_Add_2.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Add_2;
}
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number) {
ExecutionState __result_Add_1 = BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_Add_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Add_1;
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_Add_0 = BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_Add_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Add_0;
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
ExecutionState __result_AxialVectorOrSign_1 = BefuddledLabs.Magic.Instructions.Mathematics.AxialVectorOrSign.Execute(info, (UnityEngine.Vector3)_param_0.Value);
if (!__result_AxialVectorOrSign_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_AxialVectorOrSign_1;
}
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_AxialVectorOrSign_0 = BefuddledLabs.Magic.Instructions.Mathematics.AxialVectorOrSign.Execute(info, (System.Single)_param_0.Value);
if (!__result_AxialVectorOrSign_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_AxialVectorOrSign_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector) {
ExecutionState __result_Ceil_1 = BefuddledLabs.Magic.Instructions.Mathematics.Ceil.Execute(info, (UnityEngine.Vector3)_param_0.Value);
if (!__result_Ceil_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Ceil_1;
}
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_Ceil_0 = BefuddledLabs.Magic.Instructions.Mathematics.Ceil.Execute(info, (System.Single)_param_0.Value);
if (!__result_Ceil_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Ceil_0;
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
ExecutionState __result_Div_2 = BefuddledLabs.Magic.Instructions.Mathematics.Div.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
if (!__result_Div_2.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Div_2;
}
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number) {
ExecutionState __result_Div_1 = BefuddledLabs.Magic.Instructions.Mathematics.Div.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_Div_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Div_1;
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_Div_0 = BefuddledLabs.Magic.Instructions.Mathematics.Div.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_Div_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Div_0;
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
ExecutionState __result_ExpOrVectorProjection_1 = BefuddledLabs.Magic.Instructions.Mathematics.ExpOrVectorProjection.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
if (!__result_ExpOrVectorProjection_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_ExpOrVectorProjection_1;
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_ExpOrVectorProjection_0 = BefuddledLabs.Magic.Instructions.Mathematics.ExpOrVectorProjection.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_ExpOrVectorProjection_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_ExpOrVectorProjection_0;
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
ExecutionState __result_Floor_1 = BefuddledLabs.Magic.Instructions.Mathematics.Floor.Execute(info, (UnityEngine.Vector3)_param_0.Value);
if (!__result_Floor_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Floor_1;
}
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_Floor_0 = BefuddledLabs.Magic.Instructions.Mathematics.Floor.Execute(info, (System.Single)_param_0.Value);
if (!__result_Floor_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Floor_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wqaqw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean) {
ExecutionState __result_Length_3 = BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (System.Boolean)_param_0.Value);
if (!__result_Length_3.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Length_3;
}
if (_param_0.Type == ItemType.List) {
ExecutionState __result_Length_2 = BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
if (!__result_Length_2.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Length_2;
}
if (_param_0.Type == ItemType.Vector) {
ExecutionState __result_Length_1 = BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (UnityEngine.Vector3)_param_0.Value);
if (!__result_Length_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Length_1;
}
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_Length_0 = BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (System.Single)_param_0.Value);
if (!__result_Length_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Length_0;
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
ExecutionState __result_Mod_1 = BefuddledLabs.Magic.Instructions.Mathematics.Mod.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
if (!__result_Mod_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Mod_1;
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_Mod_0 = BefuddledLabs.Magic.Instructions.Mathematics.Mod.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_Mod_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Mod_0;
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
ExecutionState __result_Mult_2 = BefuddledLabs.Magic.Instructions.Mathematics.Mult.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
if (!__result_Mult_2.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Mult_2;
}
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number) {
ExecutionState __result_Mult_1 = BefuddledLabs.Magic.Instructions.Mathematics.Mult.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_Mult_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Mult_1;
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_Mult_0 = BefuddledLabs.Magic.Instructions.Mathematics.Mult.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_Mult_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Mult_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eqqq":
{
ExecutionState __result_Random01_0 = BefuddledLabs.Magic.Instructions.Mathematics.Random01.Execute(info);
if (!__result_Random01_0.Success) {
// Restore stack if execution failed
}
return __result_Random01_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wddw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
ExecutionState __result_Sub_2 = BefuddledLabs.Magic.Instructions.Mathematics.Sub.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
if (!__result_Sub_2.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Sub_2;
}
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number) {
ExecutionState __result_Sub_1 = BefuddledLabs.Magic.Instructions.Mathematics.Sub.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_Sub_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Sub_1;
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_Sub_0 = BefuddledLabs.Magic.Instructions.Mathematics.Sub.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_Sub_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Sub_0;
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
ExecutionState __result_VectorConstruct_0 = BefuddledLabs.Magic.Instructions.Mathematics.VectorConstruct.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value);
if (!__result_VectorConstruct_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
}
return __result_VectorConstruct_0;
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
ExecutionState __result_VectorDisintegration_0 = BefuddledLabs.Magic.Instructions.Mathematics.VectorDisintegration.Execute(info, (UnityEngine.Vector3)_param_0.Value);
if (!__result_VectorDisintegration_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_VectorDisintegration_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wdw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && _param_1.Type == ItemType.Boolean) {
ExecutionState __result_And_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.And.Execute(info, (System.Boolean)_param_0.Value, (System.Boolean)_param_1.Value);
if (!__result_And_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_And_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ad":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
ExecutionState __result_Equals_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.Equals.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
if (!__result_Equals_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Equals_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "e":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_GreaterThan_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.GreaterThan.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_GreaterThan_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_GreaterThan_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ee":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_GreaterThanEqual_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.GreaterThanEqual.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_GreaterThanEqual_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_GreaterThanEqual_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
ExecutionState __result_IsSomething_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.IsSomething.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
if (!__result_IsSomething_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_IsSomething_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
{
ExecutionState __result_IsSomething_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.IsSomething.Execute(info);
if (!__result_IsSomething_0.Success) {
// Restore stack if execution failed
}
return __result_IsSomething_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "q":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_LessThan_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.LessThan.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_LessThan_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_LessThan_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qq":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_LessThanEqual_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.LessThanEqual.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_LessThanEqual_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_LessThanEqual_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_Negate_1 = BefuddledLabs.Magic.Instructions.LogicalOperators.Negate.Execute(info, (System.Single)_param_0.Value);
if (!__result_Negate_1.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Negate_1;
}
if (_param_0.Type == ItemType.Boolean) {
ExecutionState __result_Negate_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.Negate.Execute(info, (System.Boolean)_param_0.Value);
if (!__result_Negate_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Negate_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "da":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
ExecutionState __result_NotEquals_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.NotEquals.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
if (!__result_NotEquals_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_NotEquals_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "waw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && _param_1.Type == ItemType.Boolean) {
ExecutionState __result_Or_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.Or.Execute(info, (System.Boolean)_param_0.Value, (System.Boolean)_param_1.Value);
if (!__result_Or_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Or_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "awdd":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && true && true) {
ExecutionState __result_Ternary_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.Ternary.Execute(info, (System.Boolean)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1, (BefuddledLabs.Magic.StackItem)_param_2);
if (!__result_Ternary_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
}
return __result_Ternary_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dwa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && _param_1.Type == ItemType.Boolean) {
ExecutionState __result_Xor_0 = BefuddledLabs.Magic.Instructions.LogicalOperators.Xor.Execute(info, (System.Boolean)_param_0.Value, (System.Boolean)_param_1.Value);
if (!__result_Xor_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Xor_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqaeaae":
{
ExecutionState __result_CreateList_0 = BefuddledLabs.Magic.Instructions.ListManipulation.CreateList.Execute(info);
if (!__result_CreateList_0.Success) {
// Restore stack if execution failed
}
return __result_CreateList_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "adeeed":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
ExecutionState __result_CreateListFromAny_0 = BefuddledLabs.Magic.Instructions.ListManipulation.CreateListFromAny.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
if (!__result_CreateListFromAny_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_CreateListFromAny_0;
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
ExecutionState __result_GetIndex_0 = BefuddledLabs.Magic.Instructions.ListManipulation.GetIndex.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_GetIndex_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_GetIndex_0;
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
ExecutionState __result_GetSlice_0 = BefuddledLabs.Magic.Instructions.ListManipulation.GetSlice.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value);
if (!__result_GetSlice_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
}
return __result_GetSlice_0;
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
ExecutionState __result_IndexOf_0 = BefuddledLabs.Magic.Instructions.ListManipulation.IndexOf.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1);
if (!__result_IndexOf_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_IndexOf_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddewedd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && true) {
ExecutionState __result_InsertAt0_0 = BefuddledLabs.Magic.Instructions.ListManipulation.InsertAt0.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1);
if (!__result_InsertAt0_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_InsertAt0_0;
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
ExecutionState __result_ListToStack_0 = BefuddledLabs.Magic.Instructions.ListManipulation.ListToStack.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
if (!__result_ListToStack_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_ListToStack_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaeaq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
ExecutionState __result_Pop_0 = BefuddledLabs.Magic.Instructions.ListManipulation.Pop.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
if (!__result_Pop_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Pop_0;
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
ExecutionState __result_Push_0 = BefuddledLabs.Magic.Instructions.ListManipulation.Push.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1);
if (!__result_Push_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Push_0;
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
ExecutionState __result_RemoveAt_0 = BefuddledLabs.Magic.Instructions.ListManipulation.RemoveAt.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_RemoveAt_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_RemoveAt_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaqwqaa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
ExecutionState __result_RemoveAt0_0 = BefuddledLabs.Magic.Instructions.ListManipulation.RemoveAt0.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
if (!__result_RemoveAt0_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_RemoveAt0_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqaede":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
ExecutionState __result_ReverseList_0 = BefuddledLabs.Magic.Instructions.ListManipulation.ReverseList.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
if (!__result_ReverseList_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_ReverseList_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wqaeaqw":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.Number && true) {
ExecutionState __result_SetIndex_0 = BefuddledLabs.Magic.Instructions.ListManipulation.SetIndex.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value, (BefuddledLabs.Magic.StackItem)_param_2);
if (!__result_SetIndex_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
}
return __result_SetIndex_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
stack.Push(_param_2);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ewdqdwe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_StackToList_0 = BefuddledLabs.Magic.Instructions.ListManipulation.StackToList.Execute(info, (System.Single)_param_0.Value);
if (!__result_StackToList_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_StackToList_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqaw":
{
ExecutionState __result_Escape_0 = BefuddledLabs.Magic.Instructions.EscapingPatterns.Escape.Execute(info);
if (!__result_Escape_0.Success) {
// Restore stack if execution failed
}
return __result_Escape_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqq":
{
ExecutionState __result_Introspection_0 = BefuddledLabs.Magic.Instructions.EscapingPatterns.Introspection.Execute(info);
if (!__result_Introspection_0.Success) {
// Restore stack if execution failed
}
return __result_Introspection_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eee":
{
ExecutionState __result_Retrospection_0 = BefuddledLabs.Magic.Instructions.EscapingPatterns.Retrospection.Execute(info);
if (!__result_Retrospection_0.Success) {
// Restore stack if execution failed
}
return __result_Retrospection_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeedw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
ExecutionState __result_Undo_0 = BefuddledLabs.Magic.Instructions.EscapingPatterns.Undo.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
if (!__result_Undo_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Undo_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddwwddwa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
ExecutionState __result_GetDrone_0 = BefuddledLabs.Magic.Instructions.Drone.GetDrone.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
if (!__result_GetDrone_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_GetDrone_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddwwdded":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
ExecutionState __result_GetPosition_0 = BefuddledLabs.Magic.Instructions.Drone.GetPosition.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
if (!__result_GetPosition_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_GetPosition_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddwwddwewa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
ExecutionState __result_GetRotation_0 = BefuddledLabs.Magic.Instructions.Drone.GetRotation.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
if (!__result_GetRotation_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_GetRotation_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddwwddad":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
ExecutionState __result_GetVelocity_0 = BefuddledLabs.Magic.Instructions.Drone.GetVelocity.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
if (!__result_GetVelocity_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_GetVelocity_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddwwddweqq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
ExecutionState __result_IsDeployed_0 = BefuddledLabs.Magic.Instructions.Drone.IsDeployed.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
if (!__result_IsDeployed_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_IsDeployed_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaq":
{
ExecutionState __result_E_0 = BefuddledLabs.Magic.Instructions.Constants.E.Execute(info);
if (!__result_E_0.Success) {
// Restore stack if execution failed
}
return __result_E_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dedq":
{
ExecutionState __result_False_0 = BefuddledLabs.Magic.Instructions.Constants.False.Execute(info);
if (!__result_False_0.Success) {
// Restore stack if execution failed
}
return __result_False_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "d":
{
ExecutionState __result_Null_0 = BefuddledLabs.Magic.Instructions.Constants.Null.Execute(info);
if (!__result_Null_0.Success) {
// Restore stack if execution failed
}
return __result_Null_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qdwdq":
{
ExecutionState __result_Pi_0 = BefuddledLabs.Magic.Instructions.Constants.Pi.Execute(info);
if (!__result_Pi_0.Success) {
// Restore stack if execution failed
}
return __result_Pi_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eawae":
{
ExecutionState __result_Tau_0 = BefuddledLabs.Magic.Instructions.Constants.Tau.Execute(info);
if (!__result_Tau_0.Success) {
// Restore stack if execution failed
}
return __result_Tau_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqae":
{
ExecutionState __result_True_0 = BefuddledLabs.Magic.Instructions.Constants.True.Execute(info);
if (!__result_True_0.Success) {
// Restore stack if execution failed
}
return __result_True_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqq":
{
ExecutionState __result_VectorZero_0 = BefuddledLabs.Magic.Instructions.Constants.VectorZero.Execute(info);
if (!__result_VectorZero_0.Success) {
// Restore stack if execution failed
}
return __result_VectorZero_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeedw":
{
ExecutionState __result_Clear_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.Clear.Execute(info);
if (!__result_Clear_0.Success) {
// Restore stack if execution failed
}
return __result_Clear_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaq":
{
ExecutionState __result_GetLocalPlayer_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.GetLocalPlayer.Execute(info);
if (!__result_GetLocalPlayer_0.Success) {
// Restore stack if execution failed
}
return __result_GetLocalPlayer_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeawa":
{
ExecutionState __result_GetPickupDirection_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.GetPickupDirection.Execute(info);
if (!__result_GetPickupDirection_0.Success) {
// Restore stack if execution failed
}
return __result_GetPickupDirection_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeaa":
{
ExecutionState __result_GetPickupPosition_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.GetPickupPosition.Execute(info);
if (!__result_GetPickupPosition_0.Success) {
// Restore stack if execution failed
}
return __result_GetPickupPosition_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
ExecutionState __result_GetPlayerEyePosition_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerEyePosition.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
if (!__result_GetPlayerEyePosition_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_GetPlayerEyePosition_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "awq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
ExecutionState __result_GetPlayerHeight_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerHeight.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
if (!__result_GetPlayerHeight_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_GetPlayerHeight_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
ExecutionState __result_GetPlayerLookDirection_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerLookDirection.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
if (!__result_GetPlayerLookDirection_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_GetPlayerLookDirection_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dd":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
ExecutionState __result_GetPlayerPosition_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerPosition.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
if (!__result_GetPlayerPosition_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_GetPlayerPosition_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "de":
{
ExecutionState __result_PrintStack_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.PrintStack.Execute(info);
if (!__result_PrintStack_0.Success) {
// Restore stack if execution failed
}
return __result_PrintStack_0;
}
// Restore stack if failed
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "weaqa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
ExecutionState __result_RaycastPlayer_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.RaycastPlayer.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
if (!__result_RaycastPlayer_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_RaycastPlayer_0;
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
ExecutionState __result_RaycastPosition_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.RaycastPosition.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
if (!__result_RaycastPosition_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_RaycastPosition_0;
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
ExecutionState __result_SetPlayerHeight_0 = BefuddledLabs.Magic.Instructions.BasicPatterns.SetPlayerHeight.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_SetPlayerHeight_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_SetPlayerHeight_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "adeeeee":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_ArcCosine_0 = BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcCosine.Execute(info, (System.Single)_param_0.Value);
if (!__result_ArcCosine_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_ArcCosine_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddeeeee":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_ArcSine_0 = BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcSine.Execute(info, (System.Single)_param_0.Value);
if (!__result_ArcSine_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_ArcSine_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eadeeeeew":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_ArcTangent_0 = BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcTangent.Execute(info, (System.Single)_param_0.Value);
if (!__result_ArcTangent_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_ArcTangent_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "deadeeeeewd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_ArcTangent2_0 = BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcTangent2.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_ArcTangent2_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_ArcTangent2_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqqad":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_Cosine_0 = BefuddledLabs.Magic.Instructions.AdvancedMathematics.Cosine.Execute(info, (System.Single)_param_0.Value);
if (!__result_Cosine_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Cosine_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eqaqe":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
ExecutionState __result_Log_0 = BefuddledLabs.Magic.Instructions.AdvancedMathematics.Log.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
if (!__result_Log_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return __result_Log_0;
}
// Restore stack if failed
stack.Push(_param_0);
stack.Push(_param_1);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "waawqqqqqaa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_Sine_0 = BefuddledLabs.Magic.Instructions.AdvancedMathematics.Sine.Execute(info, (System.Single)_param_0.Value);
if (!__result_Sine_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Sine_0;
}
// Restore stack if failed
stack.Push(_param_0);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wqqqqqadq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
ExecutionState __result_Tangent_0 = BefuddledLabs.Magic.Instructions.AdvancedMathematics.Tangent.Execute(info, (System.Single)_param_0.Value);
if (!__result_Tangent_0.Success) {
// Restore stack if execution failed
stack.Push(_param_0);
}
return __result_Tangent_0;
}
// Restore stack if failed
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
