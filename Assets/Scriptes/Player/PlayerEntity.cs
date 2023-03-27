using System;
using Core.Enums;
using Core.Tools;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        [Header("HorizontalMovement")]
        [SerializeField] private float _horizontalSpeed;

        [SerializeField] private Direction _direction;

        [Header("Jump")] 
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _gravityScale;

        [SerializeField] private DirectionalCameraPair _directionalCameraPair;
        
        private Rigidbody2D _rigidbody;
        private bool _isJumping;
        private float _startJumpVerticalPosition;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(_isJumping)
                UpdateJump();
        }

        public void MoveHorizontally(float direction)
        {
            SetDirection(direction);
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = direction * _horizontalSpeed;
            _rigidbody.velocity = velocity;
        }

        public void Jump()
        {
            if (_isJumping)
                return;

            _isJumping = true;
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _rigidbody.gravityScale = _gravityScale;
            _startJumpVerticalPosition = transform.position.y;
        }

        private void SetDirection(float direction)
        {
            if((_direction == Direction.Right && direction < 0) || 
               (_direction == Direction.Left && direction > 0))
                Flip();
        }

        private void Flip()
        {
            transform.Rotate(xAngle:0, yAngle:180, zAngle:0);
            _direction = _direction == Direction.Right ? Direction.Left : Direction.Right;
            foreach (var camera in _directionalCameraPair.DirectionalCamera)
                camera.Value.enabled = camera.Key == _direction;
        }

        private void UpdateJump()
        {
            if (_rigidbody.velocity.y < 0 && _rigidbody.position.y <= _startJumpVerticalPosition)
            {
                ResetJump();
                return;
            }
            
            
        }

        private void ResetJump()
        {
            _isJumping = false;
            _rigidbody.position = new Vector2(_rigidbody.position.x, _startJumpVerticalPosition);
            _rigidbody.gravityScale = 0;
        }
    }
}
