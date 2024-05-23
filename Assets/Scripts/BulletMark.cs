using System.Collections;
using UnityEngine;

namespace shootercourse {
    public class BulletMark : MonoBehaviour {

        private void Start() {
            Invoke(nameof(DestroyMark), 1f);
            StartCoroutine(ShrinkMark());
        }

        private IEnumerator ShrinkMark() {
            Vector3 initialScale = transform.localScale;
            float duration = 1f; // время за которое scale уменьшится до 0
            float elapsedTime = 0f;

            while (elapsedTime < duration) {
                transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localScale = Vector3.zero; // убедимся, что scale стал 0
        }

        public void DestroyMark() {
            Destroy(gameObject);
        }
    }
}
