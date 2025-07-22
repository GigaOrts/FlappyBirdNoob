using _Scripts.Core.EnvironmentLogic;
using UnityEngine;
using Zenject;

namespace _Scripts.Core.MonoBehaviours
{
    public class GroundParallaxMoverPresentation : MonoBehaviour
    {
        private GroundParallaxMover _groundParallaxMover;
        
        public void Construct(GroundParallaxMover groundParallaxMover)
        {
            _groundParallaxMover = groundParallaxMover;
        }
        
        private void Update()
        {
            _groundParallaxMover.Move();
        }
    }
}