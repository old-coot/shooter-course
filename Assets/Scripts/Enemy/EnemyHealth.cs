using UnityEngine;

namespace shootercourse {
    public class EnemyHealth : MonoBehaviour {
        [SerializeField] EnemyBodyPartManager enemyBodyPartManager;
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private EnemyStateMachine _enemyStateMachine;
        private float _health;

        private void Awake() {
            _health = _maxHealth;
        }

        public void ApplyDamage(float value, EnemyBodyPart hittenPart, Vector3 direction) {
            _health -= value;
            if (_health <= 0) {
                Die(hittenPart, direction);
            } else {
                _enemyStateMachine.StartHittedState();
            }
        }

        private void Die(EnemyBodyPart hittenPart, Vector3 direction) {

            enemyBodyPartManager.MakePhysical(hittenPart, direction);
            _enemyStateMachine.StartDieState();
        }
    }
}
