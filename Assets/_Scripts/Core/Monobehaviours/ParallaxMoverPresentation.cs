using _Scripts.Core.Environment;
using UnityEngine;

namespace _Scripts.Core.Monobehaviours
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