using System;
using _Scripts.Core.BirdLogic;
using UnityEngine;
using Zenject;

namespace _Scripts.Core.MonoBehaviours
{
    public class BirdPresentation : MonoBehaviour
    {
        public event Action Died;
        
        private BirdLifecycle _lifecycle;
        private BirdInput _input;
        private BirdController _controller;

        [Inject]
        public void Construct(BirdInput input, BirdController controller, BirdLifecycle lifecycle)
        {
            _input = input;
            _controller = controller;
            _lifecycle = lifecycle;
        }
        
        public void Die()
        {
            Died?.Invoke();
        }
        
        private void Awake()
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            var animator = GetComponent<Animator>();
            _controller.Init(rigidbody, animator);
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