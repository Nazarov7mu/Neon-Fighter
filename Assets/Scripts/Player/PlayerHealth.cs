using System;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        public static event Action OnPlayerDeath; 

        [SerializeField] private Slider _healthSlider;
        [SerializeField] private GameObject _deathParticles;

        private int _health = 100;
        
        public void ApplyDamage(int value)
        {
            _health -= value;
            UpdateSliderValue();
            
            if (_health <= 0) Die();
        }
        
        private void Start()
        {
            _health = 100;
            _healthSlider.maxValue = _health;
            UpdateSliderValue();
        }

        private void UpdateSliderValue()
        {
            _healthSlider.value = _health;
        }
        
        private void Die()
        {
            OnPlayerDeath?.Invoke();
            Instantiate(_deathParticles, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}