using _Scripts.Core.EnvironmentLogic;
using _Scripts.Core.MonoBehaviours;
using UnityEngine;

namespace _Scripts.Core.Environment
{
    public class ParallaxMoverInitialization : MonoBehaviour
    {
        [SerializeField] private float _groundSpeed = 5.1f;
        [SerializeField] private float _backgroundSpeed = 1f;
        
        [SerializeField] private ParallaxMoverPresentation _groundParallaxMoverPresentation;
        [SerializeField] private ParallaxMoverPresentation _backgroundParallaxMoverPresentation;

        private void Awake()  
        {  
            InitializeParallaxMover(_groundParallaxMoverPresentation, _groundSpeed);  
            InitializeParallaxMover(_backgroundParallaxMoverPresentation, _backgroundSpeed);  
        }  

        private void InitializeParallaxMover(ParallaxMoverPresentation presentation, float speed)  
        {  
            var spriteRenderer = presentation.GetComponent<SpriteRenderer>();  
            var parallaxMover = new ParallaxMover(spriteRenderer, speed);  
            // presentation.Construct(parallaxMover);  
        }  
    }
}