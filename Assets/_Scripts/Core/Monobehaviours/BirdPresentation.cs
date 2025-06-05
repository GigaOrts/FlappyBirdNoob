using System;
using _Scripts.Core.BirdLogic;
using UnityEngine;

namespace _Scripts.Core.MonoBehaviours
{
    public class BirdPresentation : MonoBehaviour
    {
        public event Action Died;
        
        private BirdLifecycle _lifecycle;
        private BirdInput _input;
        private BirdController _controller;

        public void Initialize(BirdLifecycle lifecycle, BirdInput input, BirdController controller)
        {
            _lifecycle = lifecycle;
            _input = input;
            _controller = controller;
        }

        public void Die()
        {
            Died?.Invoke();
        }

        private void Start()
        {
            _controller.Animator.SetFlyLoop(true);
        }

        private void Update()
        {
            if (!_lifecycle.IsReady)
                return;

            if (_input.JumpPressed())
            {
                _controller.Jump();
            }

            _controller.UpdateRotation();
        }
    }
}