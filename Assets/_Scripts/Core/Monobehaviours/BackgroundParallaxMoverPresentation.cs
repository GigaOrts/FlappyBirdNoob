using _Scripts.Core.EnvironmentLogic;
using UnityEngine;
using Zenject;

namespace _Scripts.Core.MonoBehaviours
{
    public class BackgroundParallaxMoverPresentation : MonoBehaviour
    {
        private BackgroundParallaxMover _backgroundParallaxMover;
        
        [Inject] 
        public void Construct(BackgroundParallaxMover backgroundParallaxMover)
        {
            _backgroundParallaxMover = backgroundParallaxMover;
        }
        
        private void Update()
        {
            _backgroundParallaxMover.Move();
        }
    }
}