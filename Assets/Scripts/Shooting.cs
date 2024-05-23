using System.Collections;
using UnityEngine;

namespace shootercourse {
    public class Shooting : MonoBehaviour {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private float _fireRate = 0.1f;
        [SerializeField] private float _damage = 20f;
        [SerializeField] private GameObject _flash;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _bulletMark;
        [SerializeField] private LayerMask _layerMask;


        private float _timer;
        private Coroutine _shotProcess;

        private void Update() {
            _timer += Time.deltaTime;
            if (_timer > _fireRate && Input.GetMouseButton(0)) {
                _timer = 0;
                Shot();
            }
        }

        private void Shot() {
            Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f, _layerMask)) {
                GameObject newBulletMark = Instantiate(_bulletMark, hit.point, Quaternion.LookRotation(hit.normal));
                newBulletMark.transform.parent = hit.collider.transform;

                if (hit.collider.GetComponent<EnemyBodyPart>() is EnemyBodyPart enemyBodyPart) {
                    enemyBodyPart.Hit(_damage, ray.direction);
                }

            }
            if (_shotProcess != null) {
                StopAllCoroutines();
            }
            _shotProcess = StartCoroutine(ShotProcess());
        }

        private IEnumerator ShotProcess() {
            _animator.SetTrigger("Shot");
            //TODO: MY AUDIO
            _flash.SetActive(true);
            _flash.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360f));
            _flash.transform.localScale = Vector3.one * Random.Range(0.7f, 1.5f);
            yield return new WaitForSeconds(0.02f);
            _flash.SetActive(false);
        }
    }
}
