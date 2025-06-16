using System;
using System.Collections.Generic;
using UdonSharp;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class EntityManager : UdonSharpBehaviour {
        public Transform root;
        
        [NonSerialized] public readonly Dictionary<int, Entity> Entities = new Dictionary<int, Entity>();
    }
}