using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core.ScoreLogic
{
    public class DigitsToSpriteConverter
    {
        private readonly Sprite[] _digitSprites;
        private readonly Image[] _scoreDigitObjects; 
        private readonly Image[] _highScoreDigitObjects; 
        
        private readonly Score _score; 
        private readonly HighScore _highScore;
        
        public DigitsToSpriteConverter(Score score, HighScore highScore, Sprite[] digitSprites, Image[] scoreDigitObjects, Image[] highScoreDigitObjects)
        {
            _score = score;
            _score.OnScoreChanged += ShowScore;
            
            _highScore = highScore;
            
            _digitSprites = digitSprites;
            _scoreDigitObjects = scoreDigitObjects;
            _highScoreDigitObjects = highScoreDigitObjects;
        }
        
        public void ShowHighScore() => 
            Convert(_highScore.Get(), _highScoreDigitObjects, _digitSprites);
        
        private void ShowScore(int value) => 
            Convert(value, _scoreDigitObjects, _digitSprites);
        
        private void Convert(int value, Image[] digitObjects, Sprite[] digitSprites)
        {
            int[] digits = ToDigits(value);

            for (int i = 0; i < digitObjects.Length; i++)
            {
                bool shouldShow = (i == 2) ||
                                  (i == 1 && value > 9) ||
                                  (i == 0 && value > 99); 

                digitObjects[i].gameObject.SetActive(shouldShow);
            
                if (shouldShow)
                {
                    var digit = digits[i];
                    var digitSprite = digitSprites[digit];
                    var image = digitObjects[i];
                    
                    image.sprite = digitSprite;
                    image.SetNativeSize();
                }
            }
        }

        private static int[] ToDigits(int value)
        {
            int[] digits = new int[3];
            digits[0] = (value / 100) % 10;
            digits[1] = (value / 10) % 10;
            digits[2] = value % 10;
            return digits;
        }
    }
}