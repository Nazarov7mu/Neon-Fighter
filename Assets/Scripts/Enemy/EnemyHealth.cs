using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        private GameObject _deathParticles;
        
        private float _health;

        private void Die()
        {
            Instantiate(_deathParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}