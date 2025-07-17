using System;
using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core.ScoreLogic
{
    [Obsolete]
    public class ScoreInitialization : MonoBehaviour
    {
        [SerializeField] private ScorePresentation _scorePresentation;
        [SerializeField] private BirdPresentation _birdPresentation;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;

        [Tooltip("Expected order: 0 at index 0, 1 at index 1, etc.")]
        [SerializeField] private Sprite[] _digitSprites;
        
        [Tooltip("Expected order: Hundreds, Tens, Units")]
        [SerializeField] private Image[] _scoreDigitObjects; 
        [SerializeField] private Image[] _highScoreDigitObjects;
        
        private DigitsToSpriteConverter _digitsToSpriteConverter;
        
        private void Awake()
        {
            var score = new Score();
            var highScore = new HighScore(score);
            
            _startButton.onClick.AddListener(score.Reset);
            _restartButton.onClick.AddListener(score.Reset);

            _scorePresentation.Construct(score);
            
            _digitsToSpriteConverter = new DigitsToSpriteConverter(score, highScore, _digitSprites, 
                _scoreDigitObjects, _highScoreDigitObjects);
            
            _birdPresentation.Died += _digitsToSpriteConverter.ShowHighScore;
        }
    }
}