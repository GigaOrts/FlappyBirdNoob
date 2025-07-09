using UnityEngine;
using Zenject;
using _Scripts.Core.Hazards;
using _Scripts.Core.MonoBehaviours;

namespace _Scripts.Core
{
    public class PipeFactoryInstaller : MonoInstaller
    {
        [SerializeField] private PipePresentation pipePrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform pipeContainer;

        public override void InstallBindings()
        {
            Container.Bind<PipeFactory>().AsSingle()
                .WithArguments(pipePrefab, spawnPoint.position, pipeContainer);

            Container.Bind<PipeFactoryPresentation>().AsSingle();
        }
    }
}