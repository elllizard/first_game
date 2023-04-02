using Core.Enums;
using UnityEngine;

namespace Core.Animation
{
    public class UnityAnimationController : AnimationController
    {
        private Animator _animator;

        private void Start() => _animator = GetComponent<Animator>();

        protected override void PlayAnimation(AnimationType animationType)
        {
            _animator.SetInteger(nameof(AnimationType), (int)animationType);
        }
    }
}