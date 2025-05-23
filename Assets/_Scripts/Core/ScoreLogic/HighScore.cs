using UnityEngine;

namespace _Scripts.Core.ScoreLogic
{
    public class HighScore
    {
        private const string HighScoreKey = "Highscore";
        
        private Score _score;

        public HighScore(Score score)
        {
            _score = score;
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