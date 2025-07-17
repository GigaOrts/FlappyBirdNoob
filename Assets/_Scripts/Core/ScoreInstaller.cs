using _Scripts.Core.MonoBehaviours;
using _Scripts.Core.ScoreLogic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Core
{
    public class ScoreInstaller : MonoInstaller
    {
        [Tooltip("Expected order: 0 at index 0, 1 at index 1, etc.")]
        [SerializeField] private Sprite[] _digitSprites;
        
        [Tooltip("Expected order: Hundreds, Tens, Units")]
        [SerializeField] private Image[] _scoreDigitObjects; 
        [SerializeField] private Image[] _highScoreDigitObjects;
        [SerializeField] private ScorePresentation _scorePresentation;
        
        private DigitsToSpriteConverter _digitsToSpriteConverter;

        public override void InstallBindings()
        {
            Score score = new Score();
            
            Container.Bind<Score>().FromInstance(score);
            
            Container.Bind<HighScore>().AsSingle();
            Container.Bind<ScorePresentation>().FromInstance(_scorePresentation).AsSingle();
            
            // Container.Bind<DigitsToSpriteConverter>()
            //     .WithArguments()
        }
    }
}