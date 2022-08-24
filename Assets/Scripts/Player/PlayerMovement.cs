using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [Header("Stats")]
        [SerializeField] private float _speed = 1;

        private Vector2 _movementVelocity;
        private Vector2 _movementInput;
        private Camera _camera;

        private const float Offset = 270;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            GetInput();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void GetInput()
        {
            _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        private void MovePlayer()
        {
            _movementVelocity = _movementInput * _speed;
            _rigidbody2D.MovePosition(_rigidbody2D.position + _movementVelocity * Time.fixedDeltaTime);

            Vector3 difference = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + Offset);
        }
    }
}