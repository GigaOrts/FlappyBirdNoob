using _Scripts.Core.BirdLogic;
using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Core.Installers
{
    public class BirdInstaller : MonoInstaller
    {
        public Rigidbody2D birdRigidbody;
        public Transform birdTransform;
        public Animator birdAnimatorComponent;
        
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;
        
        // public override void InstallBindings()
        // {
        //     Container.Bind<BirdInput>().AsSingle();
        //     Container.Bind<BirdPhysics>()
        //         .AsSingle()
        //         .WithArguments(birdRigidbody, birdTransform);
        //     
        //     Container.Bind<BirdAnimator>()
        //         .AsSingle()
        //         .WithArguments(birdAnimatorComponent);
        //     
        //     Container.Bind<BirdController>().AsSingle();
        //
        //     Container.Bind<BirdLifecycle>().AsSingle();
        //
        //     Container.Bind<BirdPresentation>().AsSingle();
        //     
        //     _startButton.onClick.AddListener(() =>
        //     {
        //         _lifecycle.StartGame();
        //         _controller.Jump();
        //     });
        // }
    }
}