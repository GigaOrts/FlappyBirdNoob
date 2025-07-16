using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Core
{
    public class PipeFactoryButtons: MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _startButton;

        [Inject]
        public void BindButtons(PipeFactoryPresentation pipeFactoryPresentation)
        {
            print("binding buttons");
            _startButton.onClick.AddListener(pipeFactoryPresentation.StartSpawn);
            _restartButton.onClick.AddListener(pipeFactoryPresentation.StopSpawn);
        }
    }
}