public class BirdController
{
    public BirdPhysics Physics { get; }
    public BirdAnimator Animator { get; }

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