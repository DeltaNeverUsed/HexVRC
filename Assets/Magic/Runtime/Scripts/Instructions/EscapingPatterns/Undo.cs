using System.Collections.Generic;
using VRC.Udon.Common.Interfaces;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.EscapingPatterns {
    public static class Undo {
        public const string Path = "eeedw";

        #region Docs

        public const string Description = "Removes the last Symbol from the Symbol list";
        public const string Input = "List";
        public const string Output = "List";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, List<StackItem> patterns) {
            if (patterns.Count - 1 < 0 || patterns.Count - 1 >= patterns.Count)
                return ExecutionState.Err("List was Empty");

            StackItem lastItem = patterns[patterns.Count - 1];
            patterns.RemoveAt(patterns.Count - 1);
            
            if (lastItem.Type == ItemType.Instruction)
                info.VM.glyphSpace.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(info.VM.glyphSpace.DestroyGlyph), ((Instruction)lastItem.Value).GlyphId);
            
            info.Stack.Push(new StackItem(patterns));
            return ExecutionState.Ok();
        }
    }
}