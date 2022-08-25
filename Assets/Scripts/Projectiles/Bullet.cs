using Interfaces;
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
    
        [TagSelector]
        [SerializeField] private string _tagToAvoid;

        [SerializeField] private int _damage = 10;

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = transform.up * _speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Border"))
            {
                Explode();
                return;
            }

            if (!other.CompareTag(_tagToAvoid))
            {
                IDamageable damageable = other.GetComponent<IDamageable>();
                damageable?.GetDamage(_damage);
                Explode();
            }
        }

        private void Explode()
        {
            Instantiate(_explosionEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}