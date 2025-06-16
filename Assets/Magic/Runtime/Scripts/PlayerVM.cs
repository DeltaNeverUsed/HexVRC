using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public float maxMana;

        public int stackSizeLimit = 1024;
        public int recursionLimit = 32;

        [NonSerialized] public ExecutionInfo Info;
        [NonSerialized] public Stack<StackItem[]> StackStack = new Stack<StackItem[]>();

        [NonSerialized] public bool EscapeNext;
        [NonSerialized] public bool Running;
        [NonSerialized] public int IntrospectionDepth = 0;
        [NonSerialized] public float PauseDelay = 0;
        [NonSerialized] public readonly Stack<int> SkipIndexes = new Stack<int>();

        [NonSerialized] public StorageMedium LastInteractedStorageMedium;
        [NonSerialized] public Transform ExecutionTransform;

        [NonSerialized] public List<Instruction> CurrentInstructions = new List<Instruction>();


        private readonly Stopwatch _executionTimer = new Stopwatch();

        public float GetLastExecutionTimeMs() => (float)_executionTimer.Elapsed.TotalMilliseconds;

        private float _mana;

        public ExecutionState SaveStack() {
            if (StackStack.Count >= recursionLimit)
                return ExecutionState.Err("Recursion limit hit.");

            StackStack.Push(_stack.ToArray());
            return ExecutionState.Ok();
        }

        public bool RestoreStack() {
            if (StackStack.Count <= 0)
                return false;
            StackItem[] tempItems = StackStack.Pop();
            _stack = new Stack<StackItem>();
            Info.Stack = _stack;
            foreach (StackItem item in tempItems)
                _stack.Push(item); // stupid U#
            return true;
        }

        public void SetMana(float value) {
            _mana = value;
        }

        public ExecutionState ConsumeMana(float amount) {
            _mana -= amount;
            bool ok = _mana >= 0;

            return ok
                ? ExecutionState.Ok()
                : ExecutionState.Err($"Not enough mana, you'd need at least {Mathf.Abs(_mana)} more mana to do this");
        }

        public void Start() {
            /*GameObject profiler = GameObject.Find("Profiler");
            if (Utilities.IsValid(profiler))
                profiler.GetComponent<UdonSharpProfiler.ProfilerDataReader>().Add(this);*/

            _stack = new Stack<StackItem>();
            Info = new ExecutionInfo(this, _stack, "");
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
            StackStack.Clear();
            CurrentInstructions.Clear();
            SkipIndexes.Clear();
            glyphSpace.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(glyphSpace.Clear));
        }

        public ExecutionState Execute(List<Instruction> instructions) {
            if (Running)
                return new ExecutionState(ExecutionError.Busy, "VM is busy");
            SetMana(maxMana);
            CurrentInstructions = instructions;
            Info.CurrentInstructionIndex = 0;
            return Execute_Internal();
        }

        public ExecutionState Execute_Internal() {
            _localPlayer = Networking.LocalPlayer;

            if (!_executionTimer.IsRunning)
                _executionTimer.Restart();
            if (!Utilities.IsValid(_localPlayer) || !Networking.IsOwner(_localPlayer, gameObject))
                return ExecutionState.Err("Not the owner of this VM");

            Running = true;

            List<int> glyphId = new List<int>();
            List<bool> success = new List<bool>();
            List<string> msg = new List<string>();

            ExecutionState result = ExecutionState.Ok();
            while (Info.CurrentInstructionIndex < CurrentInstructions.Count) {
                if (_executionTimer.ElapsedMilliseconds >= 6f) {
                    _executionTimer.Stop();
                    PauseDelay = 0;
                    result = new ExecutionState(ExecutionError.Paused, "");
                    Running = false;
                    break;
                }

                int index = Info.CurrentInstructionIndex;
                Instruction instruction = CurrentInstructions[index];

                if (_stack.Count > stackSizeLimit) {
                    _executionTimer.Stop();
                    glyphSpace.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(glyphSpace.UpdateGlyphStatus),
                        glyphId.ToArray(), success.ToArray(), msg.ToArray());
                    Running = false;
                    return ExecutionState.Err("Stack size limit exceeded");
                }

                // Should probably do this in a more elegant way, but this will do for now.
                if (IntrospectionDepth > 0 && !string.Equals(instruction.Path,
                        Instructions.EscapingPatterns.Retrospection.Path, StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(
                        instruction.Path, Instructions.BasicPatterns.Clear.Path, StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(
                        instruction.Path, Instructions.EscapingPatterns.Undo.Path,
                        StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(
                        instruction.Path, Instructions.EscapingPatterns.Introspection.Path,
                        StringComparison.OrdinalIgnoreCase)) {
                    ((List<StackItem>)_stack.Peek().Value).Add(new StackItem(instruction));
                    Info.CurrentInstructionIndex++;
                    continue;
                }

                if (EscapeNext) {
                    EscapeNext = false;
                    _stack.Push(new StackItem(instruction));
                    Info.CurrentInstructionIndex++;
                    continue;
                }

                result = instruction.Execute(Info);
                //instructions = infoCopy.CurrentExecutingInstructionList;

                if (Info.GlyphId != -1) {
                    glyphId.Add(instruction.GlyphId);
                    success.Add(result.IsOk());
                    msg.Add(result.IsOk() ? "" : result.Error);
                }

                if (result.Success == ExecutionError.Halt) {
                    Info.CurrentInstructionIndex++;
                    break;
                }

                if (result.Success == ExecutionError.Garbage)
                    _stack.Push(new StackItem(result.Error));

                if (result.EarlyReturnDepth > 0) {
                    result.EarlyReturnDepth--;

                    bool completelyBreak = false;
                    while (true) {
                        if (SkipIndexes.Count > 0) {
                            int skipIndex = SkipIndexes.Pop();
                            if (skipIndex <= index) // clear out old already passed ones
                                continue;
                            Info.CurrentInstructionIndex = skipIndex;
                        }
                        else
                            completelyBreak = true;

                        break;
                    }

                    if (completelyBreak)
                        break; // stop completely if not in eval
                    continue;
                }

                Info.CurrentInstructionIndex++;
            }

            if (glyphId.Count > 0)
                glyphSpace.SendCustomNetworkEvent(NetworkEventTarget.All, nameof(glyphSpace.UpdateGlyphStatus),
                    glyphId.ToArray(), success.ToArray(), msg.ToArray());

            _executionTimer.Stop();
            if (result.Success == ExecutionError.Paused)
                SendCustomEventDelayedSeconds(nameof(Execute_Internal), PauseDelay);
            else
                Running = false;
            this.Log(
                $"Execution finished in {_executionTimer.Elapsed.TotalMilliseconds}ms, sleeping until next frame? {result.Success == ExecutionError.Paused}");
            return result;
        }


        #region Networked Functions

        [NetworkCallable]
        public void ApplyImpulse(int playerId, Vector3 impulse, bool isDrone) {
            VRCPlayerApi player = VRCPlayerApi.GetPlayerById(playerId);
            if (!Utilities.IsValid(player) || !player.IsValid())
                return;
            if (!player.isLocal)
                return;

            if (isDrone) {
                VRCDroneApi drone = player.GetDrone();
                if (drone.IsDeployed())
                    drone.SetVelocity(impulse + drone.GetVelocity());
            }
            else {
                Vector3 velocity = player.GetVelocity();
                player.SetVelocity(velocity + impulse);
            }
        }

        [NetworkCallable]
        public void Blink(int playerId, float length) {
            VRCPlayerApi player = VRCPlayerApi.GetPlayerById(playerId);
            if (!Utilities.IsValid(player) || !player.IsValid())
                return;
            if (!player.isLocal)
                return;

            player.TeleportTo(player.GetPosition() + player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).rotation * Vector3.forward * length, player.GetRotation(), VRC_SceneDescriptor.SpawnOrientation.Default, false);
        }
        
        [NetworkCallable]
        public void GreaterTeleport(int playerId, Vector3 vector) {
            VRCPlayerApi player = VRCPlayerApi.GetPlayerById(playerId);
            if (!Utilities.IsValid(player) || !player.IsValid())
                return;
            if (!player.isLocal)
                return;

            player.TeleportTo(player.GetPosition() + vector, player.GetRotation(), VRC_SceneDescriptor.SpawnOrientation.Default, false);
        }

        [NetworkCallable]
        public void SetHeight(int playerId, float height) {
            VRCPlayerApi player = VRCPlayerApi.GetPlayerById(playerId);
            if (!Utilities.IsValid(player) || !player.IsValid())
                return;
            if (!player.isLocal)
                return;

            player.SetAvatarEyeHeightByMeters(Mathf.Clamp(height, 0.2f, 10f));
        }

        #endregion
    }
}