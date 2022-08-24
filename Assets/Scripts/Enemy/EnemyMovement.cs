using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [Header("Stats")]
        [SerializeField] private float _movementSpeed;
        
        private const float RotationOffset = -90;
        private Vector2 _direction;

        private Transform _target;

        private void Awake()
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;

            if (_target == null) enabled = false;
        }
        
        private void Update()
        {
            CalculateDirection(_target);
            RotateEnemy(_target);
        }

        private void CalculateDirection(Transform target)
        {
            _direction = target.position - transform.position;
            _direction.Normalize();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition((Vector2)transform.position +
                                      _direction * (_movementSpeed * Time.fixedDeltaTime));
        }

        private void RotateEnemy(Transform target)
        {
            Vector3 direction = target.position - transform.position;
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0f, rotationZ + RotationOffset);
        }
    }
}