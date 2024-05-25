using System.Collections;
using UnityEngine;

namespace shootercourse {
    public class BulletTrail : MonoBehaviour {

        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _lifeTime = 2f;


        public void Setup(Vector3 a, Vector3 b) {
            _lineRenderer.SetPosition(0, a);
            _lineRenderer.SetPosition(1, b);
            StartCoroutine(LifeProcess());
        }

        private IEnumerator LifeProcess() {
            for (float i = 0; i < 1f; i += Time.deltaTime / _lifeTime) {
                float alphaa = 1 - i;
                _lineRenderer.material.color = new Color(1, 1, 1, alphaa);
                yield return null;
            }

            Destroy(gameObject);
        }
    }
}
