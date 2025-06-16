using UnityEngine;
using VRC.Udon.Common.Interfaces;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.BasicPatterns {
    public static class PlayNote {
        public const string Path = "adaa";

        #region Docs

        public const string Description = @"Remove a vector and two numbers from the stack. Plays an instrument defined by the first number at the given location, with a note defined by the second number.

There appear to be 16 different instruments and 25 different notes. both being indexed from 0";
        public const string Input = "";
        public const string Output = "";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, Vector3 position, float instrument, float pitch) {
            info.VM.noteManager.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(info.VM.noteManager.PlayNote), position, (int)pitch, (int)instrument);
            return ExecutionState.Ok();
        }
    }
}