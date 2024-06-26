using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace shootercourse {
    public class PlayerHealth : MonoBehaviour {
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private TMP_Text _healthText;

        private float _currentHealth;

        void Start() {
            _currentHealth = _maxHealth;
            UpdateHealthUI();
        }

        void UpdateHealthUI() {
            _healthSlider.value = _currentHealth / _maxHealth;
            _healthText.text = _currentHealth.ToString() + "/" + _maxHealth.ToString();
        }

        public void TakeDamage(float amount) {
            _currentHealth -= amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            UpdateHealthUI();

            if (_currentHealth <= 0) {
                Die();
            }
        }

        void Die() {
            // ���������� ������ Die

        }

    }
}
