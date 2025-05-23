using System;

namespace _Scripts.Core.ScoreLogic
{
    public class Score
    {
        public event Action<int> OnScoreChanged;
        
        private int _value;

        public void Add(int value)
        {
            _value += value;
            OnScoreChanged?.Invoke(_value);
        }

        public void Reset()
        {
            _value = 0;
            OnScoreChanged?.Invoke(_value);
        }
    }
}