using BefuddledLabs.Magic.Instructions.BasicPatterns;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.Entities {
    public static class GetScale {
        public const string Path = "aawawwawwa";

        #region Docs

        public const string Description = "Get the scale of the entity, as a proportion of their normal size. For most entities, this will be 1.";
        public const string Input = "Player | Entity";
        public const string Output = "Number";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, VRCPlayerApi player) {
            return GetPlayerHeight.Execute(info, player);
        }
        
        public static ExecutionState Execute(ExecutionInfo info, Entity entity) {
            info.Stack.Push(new StackItem(entity.GetScale()));
            return ExecutionState.Ok();
        }
    }
}