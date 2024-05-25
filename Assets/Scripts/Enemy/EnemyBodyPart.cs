using UnityEngine;

namespace shootercourse {
    public class EnemyBodyPart : MonoBehaviour {

        [SerializeField] private float _damageMuliplier = 1f;

        private Rigidbody _rigidbody;
        private EnemyBodyPartManager _manager;

        public void Init(EnemyBodyPartManager enemyBodyPartManager) {
            _manager = enemyBodyPartManager;
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void MakePhysical() {
            _rigidbody.isKinematic = false;
        }

        public void MakeKinematic() {
            _rigidbody.isKinematic = true;
        }

        public void Hit(float damage, Vector3 direction) {
            _manager.Hit(damage * _damageMuliplier, this, direction);
        }

        public void SetVelocity(Vector3 velocity) {
            _rigidbody.velocity = velocity;
        }
    }
}
