using UnityEngine;
using UnityEngine.AI;

namespace shootercourse {
    [ExecuteAlways]
    public class EnemyTargetPoint : MonoBehaviour {

        [SerializeField] Color _color;

        private void Update() {
            if (Application.isPlaying) {
                enabled = false;
                return;
            }

            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position, out hit, Mathf.Infinity, NavMesh.AllAreas)) {
                transform.position = hit.position;
            }

        }

        private void OnDrawGizmos() {
            Gizmos.color = _color;
            Gizmos.DrawCube(transform.position + new Vector3(0f, 0.5f, 0f), new Vector3(0.3f, 1f, 0.3f));
        }

    }
}
