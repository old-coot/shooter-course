using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace shootercourse {
    public class EnemyStatePatrol : EnemyState {
        [SerializeField] private PatrolManager _patrolManager;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        [SerializeField] private float _viewingDistance = 20f;
        [SerializeField] private float _viewingAngle = 50f;

        [SerializeField] private Transform _playerCenter;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Animator _animator;

        public override void Enter() {
            base.Enter();
            _animator.SetBool("Walk", true);
            EnemyTargetPoint targetPoint = _patrolManager.GetRandomTarget();
            _navMeshAgent.SetDestination(targetPoint.transform.position);
        }

        public override void Exit() {
            base.Exit();
        }

        public override void Process() {
            base.Process();
            if (_navMeshAgent.remainingDistance < 0.5f) {
                EnemyTargetPoint targetPoint = _patrolManager.GetRandomTarget();
                _navMeshAgent.SetDestination(targetPoint.transform.position);

            }

            bool canSee = SearchUtility.SearchInSector(transform.position + Vector3.up * 1.5f, transform.forward, _playerCenter.position, _viewingAngle, _viewingDistance, _layerMask);
            if (canSee) {
                _stateMachine.StartFollowState();
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected() {
            Handles.color = new Color(0, 1f, 0.3f, 0.1f);
            Handles.DrawSolidArc(transform.position, Vector3.up, Quaternion.Euler(0, -_viewingAngle, 0) * transform.forward, _viewingAngle * 2f, _viewingDistance);
        }

#endif

    }
}
