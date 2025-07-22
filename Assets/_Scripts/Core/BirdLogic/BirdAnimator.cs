using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace _Scripts.Core.BirdLogic
{
    public class BirdAnimator
    {
        private static readonly int Fly = Animator.StringToHash("Fly");
        private static readonly int FlyLoop = Animator.StringToHash("FlyLoop");
        
        private Animator _animator;

        public void Init(Animator animator)
        {
            _animator = animator;
        }

        public void TriggerJump() => _animator.SetTrigger(Fly);

        public void SetFlyLoop(bool enabled) => _animator.SetBool(FlyLoop, enabled);
    }
}