using System;
using System.Collections.Generic;
using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using UnityEngine;
using Varneon.VUdon.Logger;
using VRC.SDK3.UdonNetworkCalling;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;


/*

type status = Ok | Err(string)

exec_instr :: instr -> stack -> (stack, status)

exec_instr (div) ([0, 0]) = ([0, 0], Err("can't div by 0"))

exec_instr (plus) ([a, b, ...]) =
    is_arithmetic(a) -> if false return Err("???")
    is_same_type(a, b) -> if false return Err("???")
    return ([a + b, ...], Ok)

enum instr_t {
    add,
    mul,
}

map = {
    instr_t.add: typeof(InstrAdd),
    instr_t.mul: typeof(InstrMul),
}

map[instr]().exec(state)

class instr {
    (stack,  status) exec(state) {
        return ....;
    }
}

*/

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    // ReSharper disable once InconsistentNaming
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class PlayerVM : UdonSharpBehaviour {
        public UdonConsole _console;
        private VRCPlayerApi _localPlayer;
        private Stack<StackItem> _stack;

        public GlyphSpace glyphSpace;

        private ExecutionInfo _info;

        [NonSerialized] public bool EscapeNext;
        [NonSerialized] public int IntrospectionDepth = 0;

        public void Start() {
            _stack = new Stack<StackItem>();
            _info = new ExecutionInfo(this, _stack, "");
            this.Log("Hello World!");
            if (Networking.IsOwner(gameObject))
                if (Utilities.IsValid(GetComponentInParent<VMManager>()))
                    GetComponentInParent<VMManager>().localVM = this;
        }

        private bool RaycastPlayer(Vector3 origin, Vector3 direction, out VRCPlayerApi player) {
            const float distance = 10;

            VRCPlayerApi[] players = new VRCPlayerApi[80];
            VRCPlayerApi.GetPlayers(players);

            player = null;

            if (!Physics.Raycast(origin, direction, out RaycastHit hit, distance))
                return false;

            foreach (VRCPlayerApi tPlayer in players) {
                if (!Utilities.IsValid(tPlayer))
                    break;

                Vector3 playerPos = tPlayer.GetPosition();
                if (!(Vector3.Distance(new Vector3(hit.point.x, 0, hit.point.z),
                          new Vector3(playerPos.x, 0, playerPos.z)) <
                      3f))
                    continue;
                player = tPlayer;
                return true;
            }

            return false;
        }

        private bool GetPlayerFromId(int id, out VRCPlayerApi player) {
            player = VRCPlayerApi.GetPlayerById(id);
            return Utilities.IsValid(player) && player.IsValid();
        }

        [NetworkCallable]
        private void Impulse(int playerId, Vector3 impulse) {
            if (!GetPlayerFromId(playerId, out VRCPlayerApi player))
                return;
            if (!player.isLocal)
                return;

            Vector3 vel = player.GetVelocity();
            vel += impulse;
            player.SetVelocity(vel);
        }

        private bool DoImpulse(VRCPlayerApi player, Vector3 impulse) {
            if (!Utilities.IsValid(player) || !player.IsValid())
                return false;
            SendCustomNetworkEvent(NetworkEventTarget.All, nameof(Impulse), player.playerId, impulse * 10);
            return true;
        }

        public void ResetVM() {
            if (!Utilities.IsValid(_localPlayer) || !Networking.IsOwner(_localPlayer, gameObject))
                return;

            IntrospectionDepth = 0;
            EscapeNext = false;

            _stack.Clear();
            glyphSpace.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(glyphSpace.Clear));
        }

        [RecursiveMethod]
        public ExecutionState Execute(List<Instruction> instructions) {
            _localPlayer = Networking.LocalPlayer;

            if (!Utilities.IsValid(_localPlayer) || !Networking.IsOwner(_localPlayer, gameObject))
                return ExecutionState.Err("Not the owner of this VM");

            foreach (Instruction instruction in instructions) {
                // Should probably do this in a more elegant way, but this will do for now.
                if (IntrospectionDepth > 0 && !string.Equals(instruction.Path,
                        Instructions.EscapingPatterns.Retrospection.Path, StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(
                        instruction.Path, Instructions.Clear.Path, StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(
                        instruction.Path, Instructions.EscapingPatterns.Undo.Path,
                        StringComparison.OrdinalIgnoreCase)) {
                    ((List<StackItem>)_stack.Peek().Value).Add(new StackItem(instruction));
                    continue;
                }

                if (EscapeNext) {
                    EscapeNext = false;
                    List<StackItem> i = new List<StackItem>(1);
                    i.Add(new StackItem(instruction));
                    _stack.Push(new StackItem(i));
                    continue;
                }

                ExecutionInfo infoCopy = (ExecutionInfo)((object[])(object)_info).Clone();
                ExecutionState result = instruction.Execute(infoCopy);
                glyphSpace.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(glyphSpace.UpdateGlyphStatus), infoCopy.GlyphId, result.Success, result.Error);

                if (!result.Success) {
                    return result;
                }
                
                if (result.EarlyReturnDepth > 0) {
                    result.EarlyReturnDepth--;
                    return result;
                }
            }

            return ExecutionState.Ok();
        }


        #region Networked Functions

        [NetworkCallable]
        public void ApplyImpulse(int playerId, Vector3 impulse) {
            VRCPlayerApi player = VRCPlayerApi.GetPlayerById(playerId);
            if (!Utilities.IsValid(player) || !player.IsValid())
                return;
            if (!player.isLocal)
                return;

            Vector3 velocity = player.GetVelocity();
            velocity += impulse;
            player.SetVelocity(velocity);
        }

        [NetworkCallable]
        public void SetHeight(int playerId, float height) {
            VRCPlayerApi player = VRCPlayerApi.GetPlayerById(playerId);
            if (!Utilities.IsValid(player) || !player.IsValid())
                return;
            if (!player.isLocal)
                return;

            player.SetAvatarEyeHeightByMeters(height);
        }

        #endregion
    }
}