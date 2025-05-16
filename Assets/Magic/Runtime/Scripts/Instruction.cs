
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
            info.Path = Path;
            Stack<StackItem> stack = info.Stack;
            int stackSize = stack.Count;
            switch (Path) {
case "eeeeedw":
return BefuddledLabs.Magic.Instructions.Clear.Execute(info);
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "awqqqwaqw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType.IsAssignableFrom(typeof(VRC.SDKBase.VRCPlayerApi)) && _param_1.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.PlayerImpulse.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Item, (UnityEngine.Vector3)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddqaa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Bury.Execute(info, (System.Object)_param_0.Item, (System.Object)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aadaadaa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && _param_1.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Copy.Execute(info, (System.Object)_param_0.Item, (System.Single)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aadaa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Duplicate.Execute(info, (System.Object)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaedd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.DuplicateSecond.Execute(info, (System.Object)_param_0.Item, (System.Object)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aadadaaw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.DuplicateTwice.Execute(info, (System.Object)_param_0.Item, (System.Object)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddad":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Move.Execute(info, (System.Single)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aada":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.StackManipulation.MoveCopy.Execute(info, (System.Single)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "a":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Pop.Execute(info, (System.Object)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaawdde":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Rearrange.Execute(info, (System.Object)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ddqdd":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.RotateL.Execute(info, (System.Object)_param_0.Item, (System.Object)_param_1.Item, (System.Object)_param_2.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaeaa":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.RotateR.Execute(info, (System.Object)_param_0.Item, (System.Object)_param_1.Item, (System.Object)_param_2.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwaeawqaeaqa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && _param_1.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.StackManipulation.StackSize.Execute(info, (System.Object)_param_0.Item, (System.Single)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aawdd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (true && true) {
return BefuddledLabs.Magic.Instructions.StackManipulation.Swap.Execute(info, (System.Object)_param_0.Item, (System.Object)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "waaw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3) && _param_1.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (UnityEngine.Vector3)_param_0.Item, (UnityEngine.Vector3)_param_1.Item);
}
if (_param_0.ItemType == typeof(System.Single) && _param_1.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Add.Execute(info, (System.Single)_param_0.Item, (System.Single)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqqaww":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.Mathematics.AxialVectorOrSign.Execute(info, (UnityEngine.Vector3)_param_0.Item);
}
if (_param_0.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.Mathematics.AxialVectorOrSign.Execute(info, (System.Single)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Ceil.Execute(info, (UnityEngine.Vector3)_param_0.Item);
}
if (_param_0.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Ceil.Execute(info, (System.Single)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wdedw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3) && _param_1.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Div.Execute(info, (UnityEngine.Vector3)_param_0.Item, (UnityEngine.Vector3)_param_1.Item);
}
if (_param_0.ItemType == typeof(System.Single) && _param_1.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Div.Execute(info, (System.Single)_param_0.Item, (System.Single)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wedew":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3) && _param_1.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.Mathematics.ExpOrVectorProjection.Execute(info, (UnityEngine.Vector3)_param_0.Item, (UnityEngine.Vector3)_param_1.Item);
}
if (_param_0.ItemType == typeof(System.Single) && _param_1.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.Mathematics.ExpOrVectorProjection.Execute(info, (System.Single)_param_0.Item, (System.Single)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ewq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Floor.Execute(info, (UnityEngine.Vector3)_param_0.Item);
}
if (_param_0.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Floor.Execute(info, (System.Single)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wqaqw":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (UnityEngine.Vector3)_param_0.Item);
}
if (_param_0.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Length.Execute(info, (System.Single)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "addwaad":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3) && _param_1.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Mod.Execute(info, (UnityEngine.Vector3)_param_0.Item, (UnityEngine.Vector3)_param_1.Item);
}
if (_param_0.ItemType == typeof(System.Single) && _param_1.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Mod.Execute(info, (System.Single)_param_0.Item, (System.Single)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "waqaw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3) && _param_1.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Mult.Execute(info, (UnityEngine.Vector3)_param_0.Item, (UnityEngine.Vector3)_param_1.Item);
}
if (_param_0.ItemType == typeof(System.Single) && _param_1.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Mult.Execute(info, (System.Single)_param_0.Item, (System.Single)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eqqq":
return BefuddledLabs.Magic.Instructions.Mathematics.Random01.Execute(info);
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wddw":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3) && _param_1.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Sub.Execute(info, (UnityEngine.Vector3)_param_0.Item, (UnityEngine.Vector3)_param_1.Item);
}
if (_param_0.ItemType == typeof(System.Single) && _param_1.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.Mathematics.Sub.Execute(info, (System.Single)_param_0.Item, (System.Single)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eqqqqq":
if (stackSize >= 3) {
StackItem _param_2 = stack.Pop();
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(System.Single) && _param_1.ItemType == typeof(System.Single) && _param_2.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.Mathematics.VectorConstruct.Execute(info, (System.Single)_param_0.Item, (System.Single)_param_1.Item, (System.Single)_param_2.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qeeeee":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.Mathematics.VectorDisintegration.Execute(info, (UnityEngine.Vector3)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qwaeawq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType.IsAssignableFrom(typeof(System.Collections.Generic.List<System.Object>))) {
return BefuddledLabs.Magic.Instructions.ListManipulation.ListToStack.Execute(info, (System.Collections.Generic.List<System.Object>)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqaede":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType.IsAssignableFrom(typeof(System.Collections.Generic.List<System.Object>))) {
return BefuddledLabs.Magic.Instructions.ListManipulation.ReverseList.Execute(info, (System.Collections.Generic.List<System.Object>)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "ewdqdwe":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.ListManipulation.StackToList.Execute(info, (System.Single)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aaq":
return BefuddledLabs.Magic.Instructions.Constants.E.Execute(info);
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dedq":
return BefuddledLabs.Magic.Instructions.Constants.False.Execute(info);
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "d":
return BefuddledLabs.Magic.Instructions.Constants.Null.Execute(info);
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qdwdq":
return BefuddledLabs.Magic.Instructions.Constants.Pi.Execute(info);
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "eawae":
return BefuddledLabs.Magic.Instructions.Constants.Tau.Execute(info);
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aqae":
return BefuddledLabs.Magic.Instructions.Constants.True.Execute(info);
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qqqqq":
return BefuddledLabs.Magic.Instructions.Constants.VectorZero.Execute(info);
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "qaq":
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetLocalPlayer.Execute(info);
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "aa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType.IsAssignableFrom(typeof(VRC.SDKBase.VRCPlayerApi))) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerEyePosition.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dd":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType.IsAssignableFrom(typeof(VRC.SDKBase.VRCPlayerApi))) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerEyeRotation.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "awq":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType.IsAssignableFrom(typeof(VRC.SDKBase.VRCPlayerApi))) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerHeight.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wa":
if (stackSize >= 1) {
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType.IsAssignableFrom(typeof(VRC.SDKBase.VRCPlayerApi))) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.GetPlayerLookDirection.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "de":
return BefuddledLabs.Magic.Instructions.BasicPatterns.PrintStack.Execute(info);
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "weaqa":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3) && _param_1.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.RaycastPlayer.Execute(info, (UnityEngine.Vector3)_param_0.Item, (UnityEngine.Vector3)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "wqaawdd":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType == typeof(UnityEngine.Vector3) && _param_1.ItemType == typeof(UnityEngine.Vector3)) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.RaycastPosition.Execute(info, (UnityEngine.Vector3)_param_0.Item, (UnityEngine.Vector3)_param_1.Item);
}
}
return ExecutionState.Err("Not enough items on Stack for any matching execution function");
case "dwe":
if (stackSize >= 2) {
StackItem _param_1 = stack.Pop();
StackItem _param_0 = stack.Pop();
if (_param_0.ItemType.IsAssignableFrom(typeof(VRC.SDKBase.VRCPlayerApi)) && _param_1.ItemType == typeof(System.Single)) {
return BefuddledLabs.Magic.Instructions.BasicPatterns.SetPlayerHeight.Execute(info, (VRC.SDKBase.VRCPlayerApi)_param_0.Item, (System.Single)_param_1.Item);
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
