using UnityEngine;

public class BirdLifecycle
{
    private readonly BirdController _controller;
    private readonly Vector3 _startPosition;
    public bool IsReady { get; private set; }

    public BirdLifecycle(BirdController controller, Vector3 startPosition)
    {
        _controller = controller;
        _startPosition = startPosition;
    }

    public void StartGame()
    {
        IsReady = true;
        _controller.Physics.EnablePhysics();
        _controller.Animator.SetFlyLoop(false);
    }

    public void Restart()
    {
        IsReady = false;
        _controller.Physics.DisablePhysics();
        _controller.Physics.Reset(_startPosition);
        _controller.Animator.SetFlyLoop(true);
    }
}