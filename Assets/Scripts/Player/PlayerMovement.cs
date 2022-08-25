using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [Header("Stats")]
        [SerializeField] private float _movementSpeed = 1;

        private Vector2 _movementVelocity;
        private Vector2 _movementInput;
        private Camera _camera;

        private float _horizontalMove;
        private float _verticalMove;

        private const float Offset = 270;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            GetInput();
            RotatePlayer();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void GetInput()
        {
            _horizontalMove = Input.GetAxis("Horizontal");
            _verticalMove = Input.GetAxis("Vertical");
        }

        private void MovePlayer()
        {
            _rigidbody2D.velocity = new Vector2(_horizontalMove * _movementSpeed,
                _verticalMove * _movementSpeed);

            _rigidbody2D.angularVelocity = 0f; // To avoid inertia movements after colliding with walls
        }

        private void RotatePlayer()
        {
            Vector3 difference = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + Offset);
        }
    }
}