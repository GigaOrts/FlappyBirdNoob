using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core
{
    public class ScoreDisplay : MonoBehaviour
    {
        // Array of digit sprites (0-9), must be assigned in the Inspector
        // Expected order: 0 at index 0, 1 at index 1, etc.
        [SerializeField] private Sprite[] _digitSprites;
        [SerializeField] private GameObject[] _scoreDigitObjects; 
        [SerializeField] private GameObject[] _highScoreDigitObjects; 
        
        private Score _score; 
        private HighScore _highScore;

        private void Start()
        {
            _score = GetComponent<Score>();
            _highScore = GetComponent<HighScore>();
            
            _score.OnScoreChanged += OnScoreChanged;
        }

        private void OnScoreChanged(int value)
        {
            DigitsToSprite(value, _scoreDigitObjects);
        }

        public void ShowHighScore()
        {
            DigitsToSprite(_highScore.Get(), _highScoreDigitObjects);
        }
        
        private void DigitsToSprite(int value, GameObject[] digitObjects)
        {
            int[] digits = new int[3];
            digits[0] = (value / 100) % 10; // Hundreds digit
            digits[1] = (value / 10) % 10;   // Tens digit
            digits[2] = value % 10;          // Units digit

            for (int i = 0; i < digitObjects.Length; i++)
            {
                // Determine if this digit should be visible:
                // - Units digit (i=2) is always visible
                // - Tens digit (i=1) only when score > 9
                // - Hundreds digit (i=0) only when score > 99
                bool shouldShow = (i == 2) ||                  // Always show units
                                  (i == 1 && value > 9) || // Show tens if > 9
                                  (i == 0 && value > 99); // Show hundreds if > 99

                digitObjects[i].SetActive(shouldShow);
            
                // If visible, update the sprite to match the digit
                if (shouldShow)
                {
                    var image = digitObjects[i].GetComponent<Image>();
                    image.sprite = _digitSprites[digits[i]];
                    image.SetNativeSize();
                }
            }
        }
    }
}