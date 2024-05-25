using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace shootercourse {
    public class EnemyStateFollow : EnemyState {

        [SerializeField] private Transform _aim;
        [SerializeField] private EnemyShooting _enemyShooting;

        private NavMeshAgent _navMeshAgent;
        private Transform _playerCenter;
        private Animator _animator;
        private float _lostPlayerTimer;

        [SerializeField] private float _viewingDistance = 20f;
        [SerializeField] private float _viewingAngle = 50f;

        [SerializeField] private LayerMask _wallMask;

        public void Init(Transform playerCenter, NavMeshAgent navMeshAgent, Animator animator, EnemyStateMachine stateMachine) {
            _stateMachine = stateMachine;
            _playerCenter = playerCenter;
            _navMeshAgent = navMeshAgent;
            _animator = animator;
        }

        public override void Enter() {
            base.Enter();
            _lostPlayerTimer = 0f;
            StartCoroutine(Behaviour());
        }


        public override void Process() {
            base.Process();

            _lostPlayerTimer += Time.deltaTime;

            bool seePlayer = SearchUtility.SearchInSector(transform.position, transform.forward, _playerCenter.position, _viewingAngle, _viewingDistance, _wallMask);

            if (seePlayer) {
                _lostPlayerTimer = 0;
            }
            if (_lostPlayerTimer > 4f) {
                _stateMachine.StartPatrolState();
            }

        }

        private IEnumerator Behaviour() {

            while (true) {

                _navMeshAgent.isStopped = false;
                _animator.SetBool("Walk", false);
                _animator.SetBool("Crouch", false);

                float timer = Random.Range(0.5f, 1.5f);

                while (timer > 0f) {
                    timer -= Time.deltaTime;

                    _aim.position = Vector3.Lerp(_aim.position, _playerCenter.position, Time.deltaTime * 5f);
                    _enemyShooting.Process();
                    yield return null;
                }
                _navMeshAgent.isStopped = true;
                _animator.SetBool("Walk", true);
                _animator.SetBool("Crouch", true);

                timer = Random.Range(0.5f, 2.5f);

                while (timer > 0f) {
                    timer -= Time.deltaTime;
                    _navMeshAgent.SetDestination(_playerCenter.transform.position);
                    _aim.position = Vector3.Lerp(_aim.position, _playerCenter.position, Time.deltaTime * 5f);

                    yield return null;
                }
                yield return null;
            }

        }
        public override void Exit() {
            base.Exit();
            StopAllCoroutines();
        }
    }


}
