using Interfaces;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private GameObject _deathParticles;
        
        private float _health = 100;

        public void ApplyDamage(int value)
        {
            _health -= value;
            if (_health <= 0)
            {
                Die();
            }
        }
        
        private void Die()
        {
            Instantiate(_deathParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}