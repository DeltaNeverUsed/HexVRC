using System.Collections.Generic;
using VRC.Udon.Common.Interfaces;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.EscapingPatterns {
    public static class Undo {
        public const string Path = "eeedw";

        #region Docs

        public const string Description = "Removes the last Symbol from the Symbol list";
        public const string Input = "";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, List<Instruction> patterns) {
            if (patterns.Count - 1 < 0 || patterns.Count - 1 >= patterns.Count)
                return ExecutionState.Err("List was Empty");
            
            int id = patterns[patterns.Count - 1].GlyphId;
            patterns.RemoveAt(patterns.Count - 1);
            
            info.VM.glyphSpace.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(info.VM.glyphSpace.DestroyGlyph), id);
            
            info.Stack.Push(patterns);
            return ExecutionState.Ok();
        }
    }
}