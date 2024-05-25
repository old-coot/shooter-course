using UnityEngine.AI;

namespace shootercourse {
    public class EnemyStateDie : EnemyState {
        private NavMeshAgent _navMesh;
        private EnemyCreator _enemyCreator;

        public void Init(NavMeshAgent navMeshAgent, EnemyCreator enemyCreator, EnemyStateMachine stateMachine) {
            _stateMachine = stateMachine;
            _navMesh = navMeshAgent;
            _enemyCreator = enemyCreator;
        }

        public override void Enter() {
            base.Enter();
            _navMesh.isStopped = true;
            Invoke(nameof(Respawn), 3f);
        }

        private void Respawn() {
            _enemyCreator.Respawn();
            Destroy(gameObject);
        }
    }
}
