using UnityEngine;
using Zenject;
using _Scripts.Core.Hazards;
using _Scripts.Core.MonoBehaviours;
using UnityEngine.UI;

namespace _Scripts.Core
{
    public class PipeFactoryInstaller : MonoInstaller
    {
        [SerializeField] private PipePresentation _pipePrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _pipeContainer;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _startButton;
        public override void InstallBindings()
        {
            PipeFactory pipeFactory = new PipeFactory(_pipePrefab, _spawnPoint.position, _pipeContainer);
            Container.Bind<PipeFactory>().FromInstance(pipeFactory).AsSingle();

            Container.Bind<PipeFactoryPresentation>().AsSingle();
        }

        [Inject]
        public void BindButtons(PipeFactoryPresentation pipeFactoryPresentation)
        {
            _startButton.onClick.AddListener(pipeFactoryPresentation.StartSpawn);
            _restartButton.onClick.AddListener(pipeFactoryPresentation.StopSpawn);
        }
    }
}