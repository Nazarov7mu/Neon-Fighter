using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private GameObject _deathParticles;

        private int _health = 100;
        
        private void Start()
        {
            _health = 100;
            _healthSlider.maxValue = _health;
        }

        private void Update()
        {
            _healthSlider.value = _health;
        }
        
        private void Die()
        {
            Instantiate(_deathParticles, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}