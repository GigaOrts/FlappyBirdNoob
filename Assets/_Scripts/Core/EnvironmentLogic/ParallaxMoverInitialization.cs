using System;
using _Scripts.Core.EnvironmentLogic;
using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Core.Environment
{
    [Obsolete]
    public class ParallaxMoverInitialization : MonoBehaviour
    {
        [SerializeField] private float _groundSpeed = 5.1f;
        [SerializeField] private float _backgroundSpeed = 1f;
        
        [FormerlySerializedAs("_groundParallaxMoverPresentation")] [SerializeField] private GroundParallaxMoverPresentation _groundGroundParallaxMoverPresentation;
        [FormerlySerializedAs("_backgroundParallaxMoverPresentation")] [SerializeField] private GroundParallaxMoverPresentation _backgroundGroundParallaxMoverPresentation;
        
        private void Awake()  
        {  
            InitializeParallaxMover(_groundGroundParallaxMoverPresentation, _groundSpeed);  
            InitializeParallaxMover(_backgroundGroundParallaxMoverPresentation, _backgroundSpeed);  
        }  
        
        private void InitializeParallaxMover(GroundParallaxMoverPresentation presentation, float speed)  
        {  
            var spriteRenderer = presentation.GetComponent<SpriteRenderer>();  
            var parallaxMover = new GroundParallaxMover(spriteRenderer, speed);  
            presentation.Construct(parallaxMover);  
        }  
    }
}