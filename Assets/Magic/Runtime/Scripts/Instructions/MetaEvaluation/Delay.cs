using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.MetaEvaluation {
    public static class Delay {
        public const string Path = "dwedwaqwedwe";

        #region Docs

        public const string Description = "Pauses the execution for an amount of seconds between 0 and 5 seconds";
        public const string Input = "Number";
        public const string Output = "";

        #endregion


        public static ExecutionState Execute(ExecutionInfo info, float delay) {
            info.VM.PauseDelay = Mathf.Clamp(delay, 0, 5f);
            return new ExecutionState(ExecutionError.Paused, "");
        }
    }
}