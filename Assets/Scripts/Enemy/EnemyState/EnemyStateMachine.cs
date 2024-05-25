using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

namespace shootercourse {
    public class EnemyStateMachine : MonoBehaviour {
        [SerializeField] private EnemyStatePatrol _enemyStatePatrol;
        [SerializeField] private EnemyStateFollow _enemyStateFollow;
        [SerializeField] private EnemyStateHitted _enemyStateHitted;
        [SerializeField] private EnemyStateDie _enemyStateDie;

        private EnemyState _currentEnemyState;

        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rig _rig;

        public void Init(EnemyCreator enemyCreator, PatrolManager patrolManager, Transform playerCenter) {
            _enemyStatePatrol.Init(this, playerCenter, patrolManager, _navMeshAgent, _animator);
            _enemyStateFollow.Init(playerCenter, _navMeshAgent, _animator, this);
            _enemyStateHitted.Init(_navMeshAgent, _animator, this, _rig);
            _enemyStateDie.Init(_navMeshAgent, enemyCreator, this);
        }


        private void Start() {
            StartPatrolState();
        }

        private void Update() {
            if (_currentEnemyState) {
                _currentEnemyState.Process();
            }
        }

        public void StartPatrolState() {
            SetState(_enemyStatePatrol);
        }
        public void StartFollowState() {
            SetState(_enemyStateFollow);
        }

        public void StartHittedState() {
            SetState(_enemyStateHitted);
        }

        public void StartDieState() {
            SetState(_enemyStateDie);
        }

        private void SetState(EnemyState enemyState) {
            if (_currentEnemyState && _currentEnemyState != enemyState) {
                _currentEnemyState.Exit();
            }

            _currentEnemyState = enemyState;
            _currentEnemyState.Enter();
        }
    }
}
