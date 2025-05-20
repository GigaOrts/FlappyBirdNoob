using UnityEngine;

namespace _Scripts.Core
{
    public class HighScore : MonoBehaviour
    {
        private const string HighScoreKey = "Highscore";
        
        private Score _score;

        private void Awake()
        {
            _score = GetComponent<Score>();
            _score.OnScoreChanged += Set;
        }

        public int Get()
        {
            return PlayerPrefs.GetInt(HighScoreKey, 0);
        }

        private void Set(int score)
        {
            int currentHighscore = Get();
            if (score > currentHighscore)
            {
                PlayerPrefs.SetInt(HighScoreKey, score);
                PlayerPrefs.Save();
            }
        }
    }
}