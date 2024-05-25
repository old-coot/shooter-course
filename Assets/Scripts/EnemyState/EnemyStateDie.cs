using UnityEngine;
using UnityEngine.AI;

namespace shootercourse {
    public class EnemyStateDie : EnemyState {
        [SerializeField] private NavMeshAgent _navMesh;

        public override void Enter() {
            base.Enter();
            _navMesh.isStopped = true;
            Invoke(nameof(Respawn), 3f);
        }

        private void Respawn() {

        }
    }
}
