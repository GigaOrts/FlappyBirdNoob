using _Scripts.Core.BirdLogic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Core
{
    public class BirdButtons : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;
        
        [Inject]
        public void Construct(BirdLifecycle lifecycle, BirdController controller)
        {
            _startButton.onClick.AddListener(() =>
            {
                lifecycle.StartGame();
                controller.Jump();
            });
            
            _restartButton.onClick.AddListener(lifecycle.Restart);
        }
    }
}