using System.Text;
using BefuddledLabs.Magic.Debug.VUdon;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

// ReSharper disable once CheckNamespace
namespace BefuddledLabs.Magic {
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class Entity : UdonSharpBehaviour {
        public EntityData entityData;
        public Transform eyeOverride;
        
        private EntityManager _entityManager;

        private int _id = -1;

        private bool _hasRigidBody;
        private Rigidbody _rigidbody;

        private bool _hasStorageMedium;
        private StorageMedium _storageMedium;

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
            
            if (!Utilities.IsValid(eyeOverride))
                eyeOverride = transform;
            if (!Utilities.IsValid(entityData))
                entityData = GetComponentInChildren<EntityData>();
            if (!Utilities.IsValid(entityData))
                entityData = GetComponent<EntityData>();
            if (!Utilities.IsValid(entityData)) {
                this.LogError("Entity Data not found");
                enabled = false;
                return;
            }
            
            _id = Animator.StringToHash(GetGameObjectPath()); // kinda cursed...

            _entityManager.Entities[_id] = this;
            _rigidbody = GetComponent<Rigidbody>();
            _hasRigidBody = Utilities.IsValid(_rigidbody);
            
            _storageMedium = GetComponent<StorageMedium>();
            _hasStorageMedium = Utilities.IsValid(_storageMedium);
        }

        private void OnDestroy() {
            if (Utilities.IsValid(_entityManager) && Utilities.IsValid(_entityManager.Entities))
                _entityManager.Entities.Remove(_id);
        }

        public void BecomeOwner() {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            Networking.SetOwner(Networking.LocalPlayer, entityData.gameObject);
        }

        #region EntityFunctions

        #region RigidBody
        public ExecutionState ApplyImpulse(Vector3 impulse) {
            if (!_hasRigidBody)
                return ExecutionState.Err("Entity is does not possess a RigidBody");

            BecomeOwner();

            _rigidbody.AddForce(impulse, ForceMode.Impulse);
            return ExecutionState.Ok();
        }
        
        public ExecutionState GetVelocity(out Vector3 velocity) {
            if (!_hasRigidBody) {
                velocity = default;
                return ExecutionState.Err("Entity is does not possess a RigidBody");
            }
            
            velocity = _rigidbody.velocity;
            return ExecutionState.Ok();
        }
        
        public ExecutionState GreaterTeleport(Vector3 vector) {
            if (!_hasRigidBody)
                return ExecutionState.Err("Entity is does not possess a RigidBody");

            BecomeOwner();
            
            transform.position += vector;
            return ExecutionState.Ok();
        }

        

        #endregion

        #region Transform

        public float GetScale() => entityData.EntityScale;

        public void SetScale(float scale) {
            BecomeOwner();
            entityData.EntityScale = scale;
        }

        #endregion
        
        #region StorageMedium
        
        public ExecutionState Write(StackItem data) {
            if (!IsWritable())
                return ExecutionState.Err("Entity is does not possess a StorageMedium");
            return _storageMedium.Write(data) ? ExecutionState.Ok() : ExecutionState.Err("Failed to write to StorageMedium");
        }

        public ExecutionState Read(out StackItem data) {
            if (!IsReadable()) {
                data = null;
                return ExecutionState.Err("Entity is does not possess a StorageMedium");
            }

            data = _storageMedium.Read();
            return ExecutionState.Ok();
        }

        public bool IsReadable() => _hasStorageMedium;
        public bool IsWritable() => _hasStorageMedium && _storageMedium.isWritable;
        
        #endregion
        
        #endregion


        public int GetId() => _id;

        public override string ToString() {
            return $"name: {name}, id: {_id}";
        }
    }
}