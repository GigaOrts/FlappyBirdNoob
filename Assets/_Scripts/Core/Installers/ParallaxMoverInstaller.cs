using _Scripts.Core.EnvironmentLogic;
using UnityEngine;
using Zenject;

public class ParallaxMoverInstaller : MonoInstaller
{
    [SerializeField] private float _groundSpeed = 5.1f;
    [SerializeField] private float _backgroundSpeed = 1f;

    public SpriteRenderer groundSpriteRenderer;
    public SpriteRenderer backgroundSpriteRenderer;

    public override void InstallBindings()
    {
        Container.Bind<ParallaxMover>()
            .AsTransient()
            .WithArguments(groundSpriteRenderer, _groundSpeed);

        // Container.Bind<ParallaxMover>()
        //     .WithId("Background")
        //     .AsTransient()
        //     .WithArguments(backgroundSpriteRenderer, _backgroundSpeed);
    }
}