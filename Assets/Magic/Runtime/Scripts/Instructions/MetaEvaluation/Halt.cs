
// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.MetaEvaluation {
    public static class Halt {
        public const string Path = "aqdee";

        #region Docs

        public const HexDir Direction = HexDir.SOUTH_WEST;
        public const string Description = "breaks out of the current executing pattern list while still executing any parent pattern lists";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info) {
            return ExecutionState.OkEarlyReturn(9999);
        }
    }
}