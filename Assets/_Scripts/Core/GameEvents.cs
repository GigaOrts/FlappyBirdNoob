using _Scripts.Core.BirdLogic;
using _Scripts.Core.MonoBehaviours;
using _Scripts.Core.ScoreLogic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Core
{
    public class GameEvents : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _startButton;
        
        [Inject]
        public void SubscribePipeFactory(PipeFactoryPresentation pipeFactoryPresentation)
        {
            _startButton.onClick.AddListener(pipeFactoryPresentation.StartSpawn);
            _restartButton.onClick.AddListener(pipeFactoryPresentation.StopSpawn);
        }
        
        [Inject]
        public void SubscribeBird(BirdLifecycle lifecycle, BirdController controller)
        {
            _startButton.onClick.AddListener(() =>
            {
                lifecycle.StartGame();
                controller.Jump();
            });
            
            _restartButton.onClick.AddListener(lifecycle.Restart);
        }

        [Inject]
		public void SubscribeBird(BirdPresentation birdPresentation, DigitsToSpriteConverter digitsToSpriteConverter)
		{
            birdPresentation.Died += digitsToSpriteConverter.ShowHighScore;
		}

        [Inject]
        public void SubscribeScore(Score score)
        {
            _startButton.onClick.AddListener(score.Reset);
            _restartButton.onClick.AddListener(score.Reset);
        }
    }
}