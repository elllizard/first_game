using Core.Movement.Data;
using UnityEngine;

namespace Core.Movement.Controller
{
    public class Jumper
    {
        private readonly JumpData _jumpData;
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;
        private float _startJumpVerticalPosition;
        public bool IsJumping { get; private set; }

        public Jumper(Rigidbody2D rigidbody, JumpData jumpData)
        {
            _rigidbody = rigidbody;
            _jumpData = jumpData;
            _transform = rigidbody.transform;
        }
        
        public void Jump()
        {
            if (IsJumping)
                return;

            IsJumping = true;
            _rigidbody.AddForce(Vector2.up * _jumpData.JumpForce);
            _rigidbody.gravityScale = _jumpData.GravityScale;
            _startJumpVerticalPosition = _transform.position.y;
        }

        public void UpdateJump()
        {
            if (_rigidbody.velocity.y < 0 && _rigidbody.position.y <= _startJumpVerticalPosition)
            {
                ResetJump();
                return;
            }
        }

        private void ResetJump()
        {
            IsJumping = false;
            _rigidbody.position = new Vector2(_rigidbody.position.x, _startJumpVerticalPosition);
            _rigidbody.gravityScale = 0;
        }
    }
}