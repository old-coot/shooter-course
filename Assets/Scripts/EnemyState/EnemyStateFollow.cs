using UnityEngine;
using UnityEngine.AI;

namespace shootercourse {
    public class EnemyStateFollow : EnemyState {

        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Transform _playerCenter;
        [SerializeField] private Animator _animator;

        public override void Enter() {
            base.Enter();
            _navMeshAgent.isStopped = false;
            _animator.SetBool("Crouch", true);
            _animator.SetBool("Walk", true);
        }

        public override void Process() {
            base.Process();
            _navMeshAgent.SetDestination(_playerCenter.position);
        }
        public override void Exit() {
            base.Exit();
            _animator.SetBool("Crouch", false);
        }
    }


}
