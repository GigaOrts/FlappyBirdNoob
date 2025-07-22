using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace _Scripts.Core.BirdLogic
{
    public class BirdController : IInitializable
    {
        public BirdPhysics Physics { get; private set; }
        public BirdAnimator Animator { get;  private set;}

        private Rigidbody2D _rigidbody;
        private Animator _animator;

        [Inject]
        public void Construct(BirdAnimator birdAnimator, BirdPhysics birdPhysics)
        {
            Physics = birdPhysics;
            Animator = birdAnimator;
        }

        public void Initialize()
        {
            
        }

        public void Init(Rigidbody2D rigidbody, Animator animator)
        {
            _animator = animator;
            Animator.Init(_animator);
            
            _rigidbody = rigidbody;
            Physics.Init(_rigidbody);
        }

        public void Jump()
        {
            Physics.Jump();
            Animator.TriggerJump();
        }

        public void UpdateRotation()
        {
            Physics.UpdateRotation();
        }
    }
}