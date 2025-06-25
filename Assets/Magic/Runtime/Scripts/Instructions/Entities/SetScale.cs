using BefuddledLabs.Magic.Instructions.BasicPatterns;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Entities {
    public static class SetScale {
        public const string Path = "ddwdwwdwwd";

        #region Docs

        public const string Description = "Set the scale of the entity, passing in a proportion of their normal size.";
        public const string Input = "Player | Entity, Number";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player, float scale) {
            return SetPlayerHeight.Execute(info, player, scale);
        }
        
        public static ExecutionState Execute(ExecutionInfo info, Entity entity, float scale) {
            entity.SetScale(scale);
            return ExecutionState.Ok();
        }
    }
}