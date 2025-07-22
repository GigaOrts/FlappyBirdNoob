using _Scripts.Core.BirdLogic;
using _Scripts.Core.MonoBehaviours;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BirdInput>().AsSingle();
        
        Container.Bind<BirdPhysics>().AsSingle();
        
        Container.Bind<BirdAnimator>().AsSingle();
        
        Container.BindInterfacesAndSelfTo<BirdController>().AsSingle();
        
        Container.Bind<BirdLifecycle>().AsSingle();
        
        Container.Bind<BirdPresentation>()
            .FromComponentInHierarchy()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<BirdInitialization>()
            .FromComponentInHierarchy()
            .AsSingle();
    }
}