
using System;
using System.Collections.Generic;
using System.Text;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class Instruction {
        public readonly string Path;
        public readonly int GlyphId = -1;
        public object ExtraData;

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

        public Instruction(string path, object extraData) {
            Path = path;
            ExtraData = extraData;
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
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aadaadaa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Copy.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aadaa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Duplicate.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaedd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.DuplicateSecond.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aadadaaw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.DuplicateTwice.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddad":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Move.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aada":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.StackManipulation.MoveCopy.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "a":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Pop.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaawdde":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Rearrange.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
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
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwaeawqaeaqa":
{
return BefuddledLabs.Magic.Instructions.StackManipulation.StackSize.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aawdd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Swap.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aweaqa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.Sets.Deduplicate.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqqqqq":
{
return BefuddledLabs.Magic.Instructions.ReadingAndWriting.ReadLast.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "deeeee":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.ReadingAndWriting.WriteLast.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqed":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsInstanceOwner.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsLocal.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsMaster.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqeq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsPlayerGrounded.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsSuspended.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqaaq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsUserInVR.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaaqqqqaq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.Player.IsValid.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
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
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqqwdeddwe":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Player.GetPlayersNear.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "AddItemToStack":
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.AddItemToStack.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "deaqq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Instruction) {
return BefuddledLabs.Magic.Instructions.MetaEvaluation.Eval.Execute(info, (BefuddledLabs.Magic.Instruction)_param_0.Value);
}
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.MetaEvaluation.Eval.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwaqde":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Instruction) {
return BefuddledLabs.Magic.Instructions.MetaEvaluation.EvalWithEarlyReturn.Execute(info, (BefuddledLabs.Magic.Instruction)_param_0.Value);
}
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.MetaEvaluation.EvalWithEarlyReturn.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqdee":
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.Halt.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dadad":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.MetaEvaluation.Map.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "RestoreStack":
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.RestoreStack.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "RestoreStackWithRemainingInList":
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.RestoreStackWithRemainingInList.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "SaveStack":
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.SaveStack.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "Skip":
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.Skip.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "waaw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_1.Value);
}
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value);
}
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
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
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wqaqw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean) {
return BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (System.Boolean)_param_0.Value);
}
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
if (_param_0.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (UnityEngine.Vector3)_param_0.Value);
}
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (System.Single)_param_0.Value);
}
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
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eqqq":
{
return BefuddledLabs.Magic.Instructions.Mathematics.Random01.Execute(info);
}
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
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qeeeee":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.VectorDisintegration.Execute(info, (UnityEngine.Vector3)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wdw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && _param_1.Type == ItemType.Boolean) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.And.Execute(info, (System.Boolean)_param_0.Value, (System.Boolean)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ad":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.Equals.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "e":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.GreaterThan.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ee":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.GreaterThanEqual.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.IsSomething.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
}
{
return BefuddledLabs.Magic.Instructions.LogicalOperators.IsSomething.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "q":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.LessThan.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qq":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.LessThanEqual.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.Negate.Execute(info, (System.Single)_param_0.Value);
}
if (_param_0.Type == ItemType.Boolean) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.Negate.Execute(info, (System.Boolean)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "da":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.NotEquals.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "waw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && _param_1.Type == ItemType.Boolean) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.Or.Execute(info, (System.Boolean)_param_0.Value, (System.Boolean)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "awdd":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && true && true) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.Ternary.Execute(info, (System.Boolean)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1, (BefuddledLabs.Magic.StackItem)_param_2);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dwa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && _param_1.Type == ItemType.Boolean) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.Xor.Execute(info, (System.Boolean)_param_0.Value, (System.Boolean)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqaeaae":
{
return BefuddledLabs.Magic.Instructions.ListManipulation.CreateList.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "adeeed":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.CreateListFromAny.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "deeed":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.ListManipulation.GetIndex.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value);
}
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
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dedqde":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.IndexOf.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddewedd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.InsertAt0.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwaeawq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.ListToStack.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaeaq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.Pop.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "edqde":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.Push.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "edqdewaqa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.ListManipulation.RemoveAt.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaqwqaa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.RemoveAt0.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqaede":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.ReverseList.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wqaeaqw":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.Number && true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.SetIndex.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value, (BefuddledLabs.Magic.StackItem)_param_2);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ewdqdwe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.ListManipulation.StackToList.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wwwqqqwwwqqeqqwwwqqwqqdqqqqqdqq":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Entity && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.GreatSpells.GreaterTeleport.Execute(info, (BefuddledLabs.Magic.Entity)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
if (_param_0.Type == ItemType.Player && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.GreatSpells.GreaterTeleport.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqaw":
{
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Escape.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqq":
{
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Introspection.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eee":
{
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Retrospection.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeedw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Undo.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddwwddwa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Drone.GetDrone.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddwwdded":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
return BefuddledLabs.Magic.Instructions.Drone.GetPosition.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddwwddwewa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
return BefuddledLabs.Magic.Instructions.Drone.GetRotation.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddwwddad":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
return BefuddledLabs.Magic.Instructions.Drone.GetVelocity.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddwwddweqq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
return BefuddledLabs.Magic.Instructions.Drone.IsDeployed.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaq":
{
return BefuddledLabs.Magic.Instructions.Constants.E.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dedq":
{
return BefuddledLabs.Magic.Instructions.Constants.False.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "d":
{
return BefuddledLabs.Magic.Instructions.Constants.Null.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qdwdq":
{
return BefuddledLabs.Magic.Instructions.Constants.Pi.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eawae":
{
return BefuddledLabs.Magic.Instructions.Constants.Tau.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqae":
{
return BefuddledLabs.Magic.Instructions.Constants.True.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeeqa":
{
return BefuddledLabs.Magic.Instructions.Constants.VectorXn.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqqea":
{
return BefuddledLabs.Magic.Instructions.Constants.VectorXp.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeeqw":
{
return BefuddledLabs.Magic.Instructions.Constants.VectorYn.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqqew":
{
return BefuddledLabs.Magic.Instructions.Constants.VectorYp.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqq":
{
return BefuddledLabs.Magic.Instructions.Constants.VectorZero.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeeqd":
{
return BefuddledLabs.Magic.Instructions.Constants.VectorZn.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqqed":
{
return BefuddledLabs.Magic.Instructions.Constants.VectorZp.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "awqqqwaq":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.Blink.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeedw":
{
return BefuddledLabs.Magic.Instructions.BasicPatterns.Clear.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaq":
{
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetLocalPlayer.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeawa":
{
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPickupDirection.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eeeeaa":
{
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPickupPosition.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerEyePosition.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "awq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerHeight.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerLookDirection.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dd":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerPosition.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "awqqqwaqw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Entity && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.Impulse.Execute(info, (BefuddledLabs.Magic.Entity)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
if (_param_0.Type == ItemType.Drone && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.Impulse.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
if (_param_0.Type == ItemType.Player && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.Impulse.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "adaa":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number && _param_2.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.PlayNote.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "de":
{
return BefuddledLabs.Magic.Instructions.BasicPatterns.PrintStack.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "weaqa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.RaycastPlayer.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wqaawdd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.RaycastPosition.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dwe":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.SetPlayerHeight.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "adeeeee":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcCosine.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddeeeee":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcSine.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eadeeeeew":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcTangent.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "deadeeeeewd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcTangent2.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqqad":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.Cosine.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eqaqe":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.Log.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "waawqqqqqaa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.Sine.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wqqqqqadq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.Tangent.Execute(info, (System.Single)_param_0.Value);
}
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
