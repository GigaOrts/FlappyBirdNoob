using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core
{
    public class ScoreDisplay : MonoBehaviour
    {
        // Array of digit sprites (0-9), must be assigned in the Inspector
        // Expected order: 0 at index 0, 1 at index 1, etc.
        [SerializeField] private Sprite[] _digitSprites;
        [SerializeField] private GameObject[] _digitObjects; 

        private Score _score; 

        private void Start()
        {
            _score = GetComponent<Score>();
            _score.OnScoreChanged += UpdateDisplay;
        }

        private void UpdateDisplay(int  score)
        {
            int currentValue = score;
        
            int[] digits = new int[3];
            digits[0] = (currentValue / 100) % 10; // Hundreds digit
            digits[1] = (currentValue / 10) % 10;   // Tens digit
            digits[2] = currentValue % 10;          // Units digit

            for (int i = 0; i < _digitObjects.Length; i++)
            {
                // Determine if this digit should be visible:
                // - Units digit (i=2) is always visible
                // - Tens digit (i=1) only when score > 9
                // - Hundreds digit (i=0) only when score > 99
                bool shouldShow = (i == 2) ||                  // Always show units
                                  (i == 1 && currentValue > 9) || // Show tens if > 9
                                  (i == 0 && currentValue > 99); // Show hundreds if > 99

                _digitObjects[i].SetActive(shouldShow);
            
                // If visible, update the sprite to match the digit
                if (shouldShow)
                {
                    var image = _digitObjects[i].GetComponent<Image>();
                    image.sprite = _digitSprites[digits[i]];
                    image.SetNativeSize();
                }
            }
        }
    }
}