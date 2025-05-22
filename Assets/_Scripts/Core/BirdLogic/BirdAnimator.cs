using UnityEngine;

namespace _Scripts.Core.BirdLogic
{
    public class BirdAnimator
    {
        private readonly Animator _animator;
        private static readonly int Fly = Animator.StringToHash("Fly");
        private static readonly int FlyLoop = Animator.StringToHash("FlyLoop");

        public BirdAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void TriggerJump() => _animator.SetTrigger(Fly);
        public void SetFlyLoop(bool enabled) => _animator.SetBool(FlyLoop, enabled);
    }
}