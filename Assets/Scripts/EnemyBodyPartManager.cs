using UnityEngine;

namespace shootercourse {
    public class EnemyBodyPartManager : MonoBehaviour {
        [SerializeField] private Animator _animator;
        [SerializeField] EnemyHealth _enemyHealth;

        private EnemyBodyPart[] _bodyParts;

        private void Awake() {
            _bodyParts = GetComponentsInChildren<EnemyBodyPart>();

            for (int i = 0; i < _bodyParts.Length; i++) {
                _bodyParts[i].Init(this);
            }
            MakeKinematic();
        }

        private void MakeKinematic() {
            for (int i = 0; i < _bodyParts.Length; i++) {
                _bodyParts[i].MakeKinematic();
            }
        }


        [ContextMenu("MakePhysical")]
        public void MakePhysical(EnemyBodyPart hittenPart, Vector3 direction) {
            for (int i = 0; i < _bodyParts.Length; i++) {
                _bodyParts[i].MakePhysical();
            }
            hittenPart.SetVelocity(direction * 40f);
            _animator.enabled = false;
        }

        public void Hit(float damage, EnemyBodyPart hittenPart, Vector3 direction) {
            _enemyHealth.ApplyDamage(damage, hittenPart, direction);
        }
    }
}
