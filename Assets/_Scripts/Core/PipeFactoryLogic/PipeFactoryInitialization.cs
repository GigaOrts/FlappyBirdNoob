using System.Collections.Generic;
using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core.Hazards
{
    public class PipeFactoryInitialization : MonoBehaviour
    {
        [SerializeField] private PipeFactoryPresentation  _pipeFactoryPresentation;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _startButton;
        
        [SerializeField] private PipePresentation _pipePresentationPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _container;
        
        private void Awake()
        {
            PipeFactory pipeFactory = new PipeFactory(_pipePresentationPrefab, _spawnPoint.position, _container);
            
            _pipeFactoryPresentation.Initialize(pipeFactory);
            
            _startButton.onClick.AddListener(_pipeFactoryPresentation.StartSpawn);
            _restartButton.onClick.AddListener(_pipeFactoryPresentation.StopSpawn);
        }
    }
}