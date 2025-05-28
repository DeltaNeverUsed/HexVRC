using System.Collections.Generic;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.LogicalOperators {
    public static class IsSomething {
        public const string Path = "aw";

        #region Docs

        public const string Description =
            "Convert an argument to a boolean. The number 0, Null, False, and the empty list become False; everything else becomes True.";

        public const string Input = "Any";
        public const string Output = "Boolean";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, StackItem any) {
            switch (any.Type) {
                case ItemType.Null:
                    info.Stack.Push(new StackItem(false));
                    break;
                case ItemType.Vector:
                    break;
                case ItemType.Number:
                    info.Stack.Push(new StackItem((float)any.Value != 0f));
                    break;
                case ItemType.Boolean:
                    info.Stack.Push(new StackItem((bool)any.Value));
                    break;
                case ItemType.Player:
                    VRCPlayerApi player = (VRCPlayerApi)any.Value;
                    info.Stack.Push(new StackItem(Utilities.IsValid(player) && player.IsValid()));
                    break;
                case ItemType.Instruction:
                    info.Stack.Push(new StackItem(true));
                    break;
                case ItemType.List:
                    List<StackItem> list = (List<StackItem>)any.Value;
                    info.Stack.Push(new StackItem(list.Count > 0));
                    break;
                case ItemType.Any:
                default:
                    info.Stack.Push(new StackItem(false));
                    break;
            }

            return ExecutionState.Ok();
        }
    }
}