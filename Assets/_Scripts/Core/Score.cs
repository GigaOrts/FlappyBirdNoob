using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;

        private int _value;

        public event Action<int> OnScoreChanged;
        private void Awake()
        {
            _startButton.onClick.AddListener(Reset);
            _restartButton.onClick.AddListener(Reset);
        }

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