using UnityEngine;

namespace shootercourse {
    public class EnemyStateMachine : MonoBehaviour {
        [SerializeField] private EnemyStatePatrol _enemyStatePatrol;
        [SerializeField] private EnemyStateFollow _enemyStateFollow;
        [SerializeField] private EnemyStateHitted _enemyStateHitted;
        private EnemyState _currentEnemyState;

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

        private void SetState(EnemyState enemyState) {
            if (_currentEnemyState && _currentEnemyState != enemyState) {
                _currentEnemyState.Exit();
            }

            _currentEnemyState = enemyState;
            _currentEnemyState.Enter();
        }
    }
}
