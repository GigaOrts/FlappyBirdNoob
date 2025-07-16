using UnityEngine;
using Zenject;
using _Scripts.Core.Hazards;
using _Scripts.Core.MonoBehaviours;

namespace _Scripts.Core
{
    public class PipeFactoryInstaller : MonoInstaller
    {
        [SerializeField] private PipeFactoryPresentation _pipeFactoryPresentation;
        [SerializeField] private PipePresentation _pipePrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _pipeContainer;
        
        public override void InstallBindings()
        {
            print("installing PipeFactory");
            PipeFactory pipeFactory = new PipeFactory(_pipePrefab, _spawnPoint.position, _pipeContainer);
            Container.Bind<PipeFactory>().FromInstance(pipeFactory).AsSingle();
            
            Container.Bind<PipeFactoryPresentation>().FromInstance(_pipeFactoryPresentation).AsSingle();
        }
    }
}