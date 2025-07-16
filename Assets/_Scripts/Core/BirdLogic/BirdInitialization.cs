using System;
using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core.BirdLogic
{
    [Obsolete]
    public class BirdInitialization : MonoBehaviour
    {
        [SerializeField] private BirdPresentation _presentation;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;

        private BirdController _controller;
        private BirdInput _input;
        private BirdLifecycle _lifecycle;

        private void Awake()
        {
            var body = _presentation.GetComponent<Rigidbody2D>();
            var animator = _presentation.GetComponent<Animator>();

            var physics = new BirdPhysics(body, _presentation.transform);
            var birdAnimator = new BirdAnimator(animator);

            _controller = new BirdController(physics, birdAnimator);
            _lifecycle = new BirdLifecycle(_controller);
            _input = new BirdInput();
            
            _presentation.Construct(_lifecycle, _input, _controller);

            _startButton.onClick.AddListener(() =>
            {
                _lifecycle.StartGame();
                _controller.Jump();
            });

            _restartButton.onClick.AddListener(_lifecycle.Restart);
        }
    }
}