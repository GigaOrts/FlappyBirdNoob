using _Scripts.Core.BirdLogic;
using UnityEngine;
using Zenject;

public class BirdLifecycle
{
    private readonly BirdController _controller;
    private Vector3 _startPosition;
    public bool IsReady { get; private set; }

    [Inject]
    public BirdLifecycle(BirdController controller)
    {
        _controller = controller;
    }

    public void SetStartPosition(Vector3 position)
    {
        _startPosition = position;
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