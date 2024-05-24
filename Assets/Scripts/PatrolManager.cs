using UnityEngine;

namespace shootercourse {
    public class PatrolManager : MonoBehaviour {
        [SerializeField] private EnemyTargetPoint[] _enemyTargetPoints;

        public EnemyTargetPoint GetRandomTarget() {
            int index = Random.Range(0, _enemyTargetPoints.Length);
            return _enemyTargetPoints[index];
        }
    }
}
