using System;
using UnityEngine;

namespace _Scripts.Core
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
        
        private void Update()
        {
            if (_lifecycle.IsReady && _input.JumpPressed())
                _controller.Jump();

            _controller.UpdateRotation();
        }
    }
}