using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class EntityData : UdonSharpBehaviour {
        public Entity entity;
        
        private Transform _entityTransform;
        private GameObject _entityGameObject;

        private Vector3 _originalScale;

        [UdonSynced, FieldChangeCallback(nameof(EntityScale))] private float _entityScale = 1;

        public float EntityScale {
            get => _entityScale;
            set {
                _entityScale = value;
                _entityTransform.localScale = _originalScale * value;
                if (Networking.IsOwner(gameObject))
                    RequestSerialization();
            }
        }

        private void Start() {
            if (!Utilities.IsValid(entity))
                entity = GetComponentInParent<Entity>();
            if (!Utilities.IsValid(entity)) {
                this.LogError("Couldn't find entity");
                enabled = false;
                return;
            }
            
            _entityTransform = entity.transform;

            _originalScale = _entityTransform.localScale;
        }
    }
}