using BefuddledLabs.Magic.Instructions.MetaEvaluation;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic.Instructions.StackManipulation {
    public static class Rearrange {
        public const string Path = "qaawdde";

        #region Docs

        public const HexDir Direction = HexDir.SOUTH_EAST;
        public const string Description =
            "Rearranges the top elements of the stack based on the given numerical code, which is the index of the permutation wanted.";
        public const string Input = "Many, Number";
        public const string Output = "Many";

        #endregion

        public static ExecutionState Execute(ExecutionInfo info, float number) {
            int code = Mathf.RoundToInt(number);
            if (code < 0)
                return ExecutionState.Err("Number must be a non-negative integer");

            List<int> strides = new List<int>();
            var acc = 1;
            var n = 1;
            while (code >= acc)
            {
                strides.Add(acc);
                acc *= n;
                n++;
            }

            if (strides.Count > info.Stack.Count)
            {
                return ExecutionState.Err("Not enough items on the stack");
            }

            var tempStack = new List<StackItem>();
            for (int i = 0; i < strides.Count; i++)
            {
                tempStack.Insert(0, info.Stack.Pop());
            }

            strides.Reverse();
            
            var radix = code;
            foreach (var divisor in strides)
            {
                var index = radix / divisor;
                radix %= divisor;

                info.Stack.Push(tempStack[index]);
                tempStack.RemoveAt(index);
            }

            return ExecutionState.Ok();
        }
    }
}