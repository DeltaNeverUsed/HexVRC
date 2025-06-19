
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    public class Instruction {
        public readonly string Path;
        public readonly int GlyphId = -1;
        public object ExtraData;

        public readonly int Hash;

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
            Hash = Animator.StringToHash(Path);
        }

        public Instruction(string path, object extraData) {
            Path = path;
            Hash = Animator.StringToHash(Path);
            ExtraData = extraData;
        }

        public Instruction(string path, int glyphId) {
            GlyphId = glyphId;
            Path = path;
            Hash = Animator.StringToHash(Path);
        }
        
        public ExecutionState Execute(ExecutionInfo info) {
            info.Path = Path;
            info.GlyphId = GlyphId;
            Stack<StackItem> stack = info.Stack;
            int stackSize = stack.Count;
            switch (Hash) {
case 229920651:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Bury.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -377302242:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Copy.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -395882158:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Duplicate.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -457688145:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.DuplicateSecond.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 742610070:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.DuplicateTwice.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -320396525:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Move.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -789638912:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.StackManipulation.MoveCopy.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -390611389:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Pop.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 905332302:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Rearrange.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 11095873:
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.RotateL.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1, (BefuddledLabs.Magic.StackItem)_param_2);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -375047323:
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.RotateR.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1, (BefuddledLabs.Magic.StackItem)_param_2);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 590124647:
{
return BefuddledLabs.Magic.Instructions.StackManipulation.StackSize.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -82162511:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Swap.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1894055644:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.Sets.Deduplicate.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 558790816:
{
return BefuddledLabs.Magic.Instructions.ReadingAndWriting.ReadLast.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 348327965:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.ReadingAndWriting.WriteLast.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1684830686:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsInstanceOwner.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 308394534:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsLocal.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 146501211:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsMaster.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1020226931:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsPlayerGrounded.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1008479629:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsSuspended.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -294559468:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Player.IsUserInVR.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -372642427:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.Player.IsValid.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -2056829164:
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
case 1372210685:
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
case 679152739:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Player.GetPlayersNear.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1881331538:
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.AddItemToStack.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1350440260:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.MetaEvaluation.Delay.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -27555413:
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
case -793843091:
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
case -612431920:
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.Halt.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1357720237:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.MetaEvaluation.Map.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1449777739:
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.RestoreStack.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1247538079:
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.RestoreStackWithRemainingInList.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 542970291:
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.SaveStack.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1480915523:
{
return BefuddledLabs.Magic.Instructions.MetaEvaluation.Skip.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 742283351:
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
case 2139287459:
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
case -137059949:
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
case -1200035743:
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
case 404608114:
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
case -165577150:
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
case -285015804:
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
case -960576901:
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
case -369170502:
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
case 1772737367:
{
return BefuddledLabs.Magic.Instructions.Mathematics.Random01.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1468165881:
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
case -1159775562:
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number && _param_2.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.Mathematics.VectorConstruct.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1205371701:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.Mathematics.VectorDisintegration.Execute(info, (UnityEngine.Vector3)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1628433915:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && _param_1.Type == ItemType.Boolean) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.And.Execute(info, (System.Boolean)_param_0.Value, (System.Boolean)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 2011229528:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.Equals.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -270894502:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.GreaterThan.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1686837450:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.GreaterThanEqual.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -211899258:
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
case -184504793:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.LessThan.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1358896098:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.LessThanEqual.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1909892925:
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
case 2063461778:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.NotEquals.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 477632958:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && _param_1.Type == ItemType.Boolean) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.Or.Execute(info, (System.Boolean)_param_0.Value, (System.Boolean)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1204929971:
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && true && true) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.Ternary.Execute(info, (System.Boolean)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1, (BefuddledLabs.Magic.StackItem)_param_2);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -363592687:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Boolean && _param_1.Type == ItemType.Boolean) {
return BefuddledLabs.Magic.Instructions.LogicalOperators.Xor.Execute(info, (System.Boolean)_param_0.Value, (System.Boolean)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1215500945:
{
return BefuddledLabs.Magic.Instructions.ListManipulation.CreateList.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 241801352:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.CreateListFromAny.Execute(info, (BefuddledLabs.Magic.StackItem)_param_0);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1172237623:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.ListManipulation.GetIndex.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 677893285:
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.Number && _param_2.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.ListManipulation.GetSlice.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1370796651:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.IndexOf.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -744974091:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.InsertAt0.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1737977816:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.ListToStack.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1796031357:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.Pop.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1255036519:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.Push.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (BefuddledLabs.Magic.StackItem)_param_1);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1617416031:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.ListManipulation.RemoveAt.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1379867845:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.RemoveAt0.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 577810723:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.ListManipulation.ReverseList.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1831320396:
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List && _param_1.Type == ItemType.Number && true) {
return BefuddledLabs.Magic.Instructions.ListManipulation.SetIndex.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value, (System.Single)_param_1.Value, (BefuddledLabs.Magic.StackItem)_param_2);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -7565781:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.ListManipulation.StackToList.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1540197969:
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
case 916931973:
{
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Escape.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1152069016:
{
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Introspection.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1810900244:
{
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Retrospection.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 451169254:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.List) {
return BefuddledLabs.Magic.Instructions.EscapingPatterns.Undo.Execute(info, (System.Collections.Generic.List<BefuddledLabs.Magic.StackItem>)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1291934417:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.Drone.GetDrone.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1168105101:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
return BefuddledLabs.Magic.Instructions.Drone.GetPosition.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1464084184:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
return BefuddledLabs.Magic.Instructions.Drone.GetRotation.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -569580425:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
return BefuddledLabs.Magic.Instructions.Drone.GetVelocity.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -480874806:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Drone) {
return BefuddledLabs.Magic.Instructions.Drone.IsDeployed.Execute(info, (VRC.SDKBase.VRCDroneApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -307207351:
{
return BefuddledLabs.Magic.Instructions.Constants.E.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -40937078:
{
return BefuddledLabs.Magic.Instructions.Constants.False.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1730327860:
{
return BefuddledLabs.Magic.Instructions.Constants.Null.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1040592918:
{
return BefuddledLabs.Magic.Instructions.Constants.Pi.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 82456226:
{
return BefuddledLabs.Magic.Instructions.Constants.Tau.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1227652564:
{
return BefuddledLabs.Magic.Instructions.Constants.True.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 58510699:
{
return BefuddledLabs.Magic.Instructions.Constants.VectorXn.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1999640648:
{
return BefuddledLabs.Magic.Instructions.Constants.VectorXp.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -139954118:
{
return BefuddledLabs.Magic.Instructions.Constants.VectorYn.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -2082165479:
{
return BefuddledLabs.Magic.Instructions.Constants.VectorYp.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1794706719:
{
return BefuddledLabs.Magic.Instructions.Constants.VectorZero.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1930836452:
{
return BefuddledLabs.Magic.Instructions.Constants.VectorZn.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 123399367:
{
return BefuddledLabs.Magic.Instructions.Constants.VectorZp.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1917246318:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.Blink.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1071800786:
{
return BefuddledLabs.Magic.Instructions.BasicPatterns.Clear.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -241778631:
{
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetLocalPlayer.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1378861617:
{
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPickupDirection.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -1130446171:
{
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPickupPosition.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 126491095:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerEyePosition.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -248981858:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerHeight.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 454208512:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerLookDirection.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 177674525:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerPosition.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 49234014:
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
case -1420613714:
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Number && _param_2.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.PlayNote.Execute(info, (UnityEngine.Vector3)_param_0.Value, (System.Single)_param_1.Value, (System.Single)_param_2.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 2106599819:
{
return BefuddledLabs.Magic.Instructions.BasicPatterns.PrintStack.Execute(info);
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -995330915:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.RaycastPlayer.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1239766035:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Vector && _param_1.Type == ItemType.Vector) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.RaycastPosition.Execute(info, (UnityEngine.Vector3)_param_0.Value, (UnityEngine.Vector3)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -314982392:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Player && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.SetPlayerHeight.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 363604369:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcCosine.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1200883254:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcSine.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 245435333:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcTangent.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 467526104:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.ArcTangent2.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 1664494019:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.Cosine.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case 110802094:
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number && _param_1.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.Log.Execute(info, (System.Single)_param_0.Value, (System.Single)_param_1.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -519661938:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.Sine.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case -521703713:
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.Type == ItemType.Number) {
return BefuddledLabs.Magic.Instructions.AdvancedMathematics.Tangent.Execute(info, (System.Single)_param_0.Value);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");

            }if (Path.StartsWith("aqaa", StringComparison.InvariantCulture)) {return BefuddledLabs.Magic.Instructions.NumberLiterals.NumberLiteralPositive.Execute(info);
}
if (Path.StartsWith("dedd", StringComparison.InvariantCulture)) {return BefuddledLabs.Magic.Instructions.NumberLiterals.NumberLiteralNegative.Execute(info);
}
if (Path.StartsWith("", StringComparison.InvariantCulture)) {return BefuddledLabs.Magic.Instructions.StackManipulation.Mask.Execute(info);
}

            return ExecutionState.Err("Path was not a valid instruction.");
        }

    }
}
