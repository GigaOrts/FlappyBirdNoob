using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core.ScoreLogic
{
    public class ScoreInitialization : MonoBehaviour
    {
        [SerializeField] private ScorePresentation _scorePresentation;
        [SerializeField] private BirdPresentation _birdPresentation;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;

        [Tooltip("Expected order: 0 at index 0, 1 at index 1, etc.")]
        [SerializeField] private Sprite[] _digitSprites;
        
        [Tooltip("Expected order: Hundreds, Tens, Units")]
        [SerializeField] private GameObject[] _scoreDigitObjects; 
        [SerializeField] private GameObject[] _highScoreDigitObjects;
        
        private Score _score;
        private DigitsToSpriteConverter _digitsToSpriteConverter;
        private HighScore _highScore;
        
        private void Awake()
        {
            _score = new Score();
            _highScore = new HighScore(_score);
            
            _startButton.onClick.AddListener(_score.Reset);
            _restartButton.onClick.AddListener(_score.Reset);

            _scorePresentation.Initialize(_score);
            
            _digitsToSpriteConverter = new DigitsToSpriteConverter(_score, _highScore, _digitSprites, 
                _scoreDigitObjects, _highScoreDigitObjects);
            
            _birdPresentation.Died += _digitsToSpriteConverter.ShowHighScore;
        }
    }
}