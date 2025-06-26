using Zenject;

namespace _Scripts.Core.BirdLogic
{
    public class BirdController
    {
        public BirdPhysics Physics { get; }
        public BirdAnimator Animator { get; }

        // [Inject]
        public BirdController(BirdPhysics physics, BirdAnimator animator)
        {
            Physics = physics;
            Animator = animator;
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