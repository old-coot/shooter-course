using UnityEngine;

namespace shootercourse {
    public class EnemyState : MonoBehaviour {

        [SerializeField] protected EnemyStateMachine _stateMachine;

        public virtual void Enter() {
        }

        public virtual void Process() {
        }

        public virtual void Exit() {
        }
    }
}
