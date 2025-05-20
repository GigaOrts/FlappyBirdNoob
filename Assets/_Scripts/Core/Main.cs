using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private PipeSpawner _pipeSpawner;
        [SerializeField] private Bird _bird;

        [SerializeField] private GameObject _gameOverMenu;
        [SerializeField] private GameObject _getReadyMenu;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _startButton;
//todo declare StartGame event, not only RESTARTGAME
        private void Awake()
        {
            _startButton.onClick.AddListener(OnStart);
            _restartButton.onClick.AddListener(OnRestart);
            _bird.Died += OnDied;
        }

        private void Start()
        {
            SetGetReadyState();
        }

        private void SetGetReadyState()
        {
            ShowGetReadyMenu();
            UnpauseGame();
        }

        private void OnStart()
        {
            HideGetReadyMenu();
        }

        private void OnRestart()
        {
            HideGameOverMenu();
            SetGetReadyState();
        }

        private void ShowGetReadyMenu()
        {
            _getReadyMenu.SetActive(true);
        }
        
        private void HideGetReadyMenu()
        {
            _getReadyMenu.SetActive(false);
        }

        private void OnDied()
        {
            PauseGame();
            ShowGameOverMenu();
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
        }

        private void UnpauseGame()
        {
            Time.timeScale = 1;
        }
        
        private void RestartGame()
        {
            
        }
        
        private void ShowGameOverMenu()
        {
            _gameOverMenu.SetActive(true);
        }

        private void HideGameOverMenu()
        {
            _gameOverMenu.SetActive(false);
        }
    }
}
