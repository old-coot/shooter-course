using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

namespace shootercourse {
    public class EnemyStateHitted : EnemyState {

        [SerializeField] private AnimationCurve _animationCurve;

        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private Rig _rig;

        public void Init(
            NavMeshAgent navMeshAgent,
            Animator animator,
            EnemyStateMachine stateMachine,
            Rig rig) {
            _stateMachine = stateMachine;
            _navMeshAgent = navMeshAgent;
            _animator = animator;
            _rig = rig;
        }



        public override void Enter() {
            base.Enter();
            StartCoroutine(HitProcess());
        }


        public override void Process() {
            base.Process();
        }

        private IEnumerator HitProcess() {
            _navMeshAgent.isStopped = true;
            _animator.SetTrigger("Hit");

            for (float t = 0; t < 1f; t += Time.deltaTime / 0.6f) {
                _rig.weight = _animationCurve.Evaluate(t);
                yield return null;
            }
            _rig.weight = 1f;
            _stateMachine.StartFollowState();
        }
        public override void Exit() {
            base.Exit();
            _rig.weight = 1f;
            StopAllCoroutines();
        }
    }
}
