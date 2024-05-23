using UnityEngine;

namespace shootercourse {
    public class GameManager : MonoBehaviour {
        private void Start() {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
