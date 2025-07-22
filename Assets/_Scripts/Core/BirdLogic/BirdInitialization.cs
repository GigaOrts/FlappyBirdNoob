using System;
using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Core.BirdLogic
{
    public class BirdInitialization : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;

        private BirdController _controller;
        private BirdLifecycle _lifecycle;
        
        [Inject]
        public void Construct(BirdController controller, BirdLifecycle lifecycle)
        {
            _controller =controller;
            _lifecycle = lifecycle;
        }

        public void Initialize()
        {
            _startButton.onClick.AddListener(BirdStart);
            _restartButton.onClick.AddListener(_lifecycle.Restart);
        }

        private void BirdStart()
        {
            _lifecycle.StartGame();
            _controller.Jump();
        }

        public void Dispose()
        {
            _startButton.onClick.RemoveListener(BirdStart);
            _restartButton.onClick.RemoveListener(_lifecycle.Restart);
        }
    }
}