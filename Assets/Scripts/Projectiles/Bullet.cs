using UnityEngine;

namespace Projectiles
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject _explosionEffect;
    
        [Header("Components")]
        [SerializeField] private Rigidbody2D _rigidbody2D;
    
        [Header("Stats")]
        [SerializeField] private float _speed;
    
        private void FixedUpdate()
        {
            _rigidbody2D.velocity = transform.up * _speed;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
        
        }

        private void Explode()
        {
            Destroy(gameObject);
        }
    }
}