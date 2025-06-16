using System.Text;
using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class Entity : UdonSharpBehaviour {
        private EntityManager _entityManager;

        private int _id = -1;

        private bool _hasRigidBody;
        private Rigidbody _rigidbody;

        private string GetGameObjectPath() {
            GameObject obj = gameObject;
            StringBuilder sb = new StringBuilder();
            sb.Insert(0, obj.name);
            sb.Insert(0, '/');

            while (Utilities.IsValid(obj.transform.parent)) {
                obj = obj.transform.parent.gameObject;
                sb.Insert(0, obj.name);
                sb.Insert(0, '/');
            }

            return sb.ToString();
        }

        private void OnEnable() {
            if (!Utilities.IsValid(_entityManager)) {
                _entityManager = GameObject.Find("EntityManager").GetComponent<EntityManager>();
                if (!Utilities.IsValid(_entityManager)) {
                    this.LogError("EntityManager not found");
                    enabled = false;
                    return;
                }
            }

            if (_id != -1)
                return;
            
            _id = Animator.StringToHash(GetGameObjectPath()); // kinda cursed...

            _entityManager.Entities[_id] = this;
            _rigidbody = GetComponent<Rigidbody>();
            _hasRigidBody = Utilities.IsValid(_rigidbody);
        }

        private void OnDestroy() {
            if (Utilities.IsValid(_entityManager))
                _entityManager.Entities.Remove(_id);
        }

        #region EntityFunctions

        #region RigidBody
        public ExecutionState ApplyImpulse(Vector3 impulse) {
            if (!_hasRigidBody)
                return ExecutionState.Err("Entity is does not possess a RigidBody");

            Networking.SetOwner(Networking.LocalPlayer, gameObject); // become owner to apply force

            _rigidbody.AddForce(impulse, ForceMode.Impulse);
            return ExecutionState.Ok();
        }
        
        public ExecutionState GreaterTeleport(Vector3 vector) {
            if (!_hasRigidBody)
                return ExecutionState.Err("Entity is does not possess a RigidBody");

            Networking.SetOwner(Networking.LocalPlayer, gameObject); // become owner to apply force

            transform.position += vector;
            return ExecutionState.Ok();
        }

        

        #endregion


        #endregion


        public int GetId() => _id;

        public override string ToString() {
            return $"name: {name}, id: {_id}";
        }
    }
}