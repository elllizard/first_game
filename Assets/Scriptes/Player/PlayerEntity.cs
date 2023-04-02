using Core.Animation;
using Core.Enums;
using Core.Movement.Controller;
using Core.Movement.Data;
using Core.Tools;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private AnimationController _animator;
        [SerializeField] private DirectionalMovementData _directionalMovementData;
        [SerializeField] private JumpData _jumpData;
        [SerializeField] private DirectionalCameraPair _directionalCameraPair;
        
        private Rigidbody2D _rigidbody;
        private DirectionMover _directionMover;
        private Jumper _jumper;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _directionMover = new DirectionMover(_rigidbody, _directionalMovementData);
            _jumper = new Jumper(_rigidbody, _jumpData);
        }

        private void Update()
        {
            if(_jumper.IsJumping)
                _jumper.UpdateJump();

            UpdateAnimations();
            UpdateCameras();
        }

        private void UpdateCameras()
        {
            foreach (var cameraPair in _directionalCameraPair.DirectionalCamera)
                cameraPair.Value.enabled = cameraPair.Key == _directionMover.Direction;
        }

        private void UpdateAnimations()
        {
            _animator.PlayAnimation(AnimationType.Idle, true);
            _animator.PlayAnimation(AnimationType.Walk, _directionMover.IsMoving);
            _animator.PlayAnimation(AnimationType.Jump, _jumper.IsJumping);
        }

        public void MoveHorizontally(float direction) => _directionMover.MoveHorizontally(direction);

        public void Jump() => _jumper.Jump();
        
    }
}