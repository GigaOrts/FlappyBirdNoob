using _Scripts.Core.Hazards;
using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core
{

    public class Main : MonoBehaviour
    {
        [SerializeField] private PipeFactoryPresentation _pipeFactoryPresentation;
        [SerializeField] private BirdPresentation _birdPresentation;

        [SerializeField] private GameObject _gameOverMenu;
        [SerializeField] private GameObject _getReadyMenu;
        [SerializeField] private GameObject _score;

        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            _startButton.onClick.AddListener(OnStart);
            _restartButton.onClick.AddListener(OnRestart);
            _birdPresentation.Died += OnDied;
        }

        private void Start()
        {
            SetGetReadyState();
        }

        private void SetGetReadyState()
        {
            ShowGetReadyMenu();
            HideScore();
            HideGameOverMenu();
            UnpauseGame();
        }

        private void OnStart()
        {
            HideGetReadyMenu();
            ShowScore();
        }

        private void ShowScore()
        {
            _score.SetActive(true);
        }
        
        private void HideScore()
        {
            _score.SetActive(false);
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

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void UnpauseGame()
        {
            Time.timeScale = 1;
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
