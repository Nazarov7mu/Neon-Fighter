using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [Header("Scripts")]
        [SerializeField] private EnemyTarget _enemyTarget;
        
        [Header("Components")] 
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [Header("Stats")]
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _minDistance;
        
        private const float RotationOffset = -90;
        private Vector2 _direction;

        private Transform _target;
        private bool _isInRange;

        private void Start()
        {
            _target = _enemyTarget.Target;
        }

        private void Update()
        {
            if (_target == null) return;
            
            CalculateDirection(_target);
            RotateEnemy(_target);
            CheckForRange();
        }
        
        private void FixedUpdate()
        {
            Move();
        }
        
        private void CalculateDirection(Transform target)
        {
            _direction = target.position - transform.position;
            _direction.Normalize();
        }

        private void RotateEnemy(Transform target)
        {
            Vector3 direction = target.position - transform.position;
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0f, rotationZ + RotationOffset);
        }

        private void CheckForRange()
        {
            _isInRange = Vector2.Distance(transform.position, _target.position) < _minDistance;
        }
        
        private void Move()
        {
            if (_isInRange) return;
            
            _rigidbody2D.MovePosition((Vector2)transform.position +
                                      _direction * (_movementSpeed * Time.fixedDeltaTime));
        }
    }
}