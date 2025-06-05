using _Scripts.Core.EnvironmentLogic;
using UnityEngine;

namespace _Scripts.Core.MonoBehaviours
{
    public class ParallaxMoverPresentation : MonoBehaviour
    {
        private ParallaxMover _parallaxMover;
        
        public void Initialize(ParallaxMover parallaxMover)
        {
            _parallaxMover = parallaxMover;
        }
        
        private void Update()
        {
            _parallaxMover.Move();
        }
    }
}