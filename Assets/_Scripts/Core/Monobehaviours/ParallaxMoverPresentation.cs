using _Scripts.Core.EnvironmentLogic;
using UnityEngine;
using Zenject;

namespace _Scripts.Core.MonoBehaviours
{
    public class ParallaxMoverPresentation : MonoBehaviour
    {
        private ParallaxMover _parallaxMover;
        
        [Inject(Id = "Ground")] 
        public void Construct1(ParallaxMover parallaxMover)
        {
            _parallaxMover = parallaxMover;
        }
        
        [Inject(Id = "Background")] 
        public void Construct2(ParallaxMover parallaxMover)
        {
            _parallaxMover = parallaxMover;
        }
        
        private void Update()
        {
            _parallaxMover.Move();
        }
    }
}