using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace shootercourse {
    public class EnemyCreator : MonoBehaviour {
        [SerializeField] private int _number;
        [SerializeField] private EnemyStateMachine _enemyPrefab;
        [SerializeField] private PatrolManager _patrolManager;
        [SerializeField] private Transform _playerCenter;

        private List<Transform> _spawnPoints = new List<Transform>();

        private void Awake() {
            _spawnPoints = GetComponentsInChildren<Transform>().ToList();
            _spawnPoints.Remove(transform);
        }
        private void Start() {
            for (int i = 0; i < _number; i++) {
                CreateOne();
            }
        }

        private void CreateOne() {
            Transform randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            EnemyStateMachine newEnemy = Instantiate(_enemyPrefab, randomPoint.position, randomPoint.rotation);
            newEnemy.Init(this, _patrolManager, _playerCenter);

        }

        public void Respawn() { CreateOne(); }

    }
}
