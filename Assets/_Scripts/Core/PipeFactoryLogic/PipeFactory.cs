using System.Collections.Generic;
using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace _Scripts.Core.Hazards
{
    public class PipeFactory
    {
        private readonly float _yPositionMinRange = -1.5f;
        private readonly float _yPositionMaxRange = 3.5f;
        
        private readonly PipePresentation _prefab;
        private readonly List<PipePresentation> _pipes;
        
        private readonly Vector2 _spawnPosition;
        private readonly Transform _parent;

        public float SpawnDelay { get; }

		// [Inject]
        public PipeFactory(PipePresentation prefab, Vector2 spawnPosition, Transform parent)
        {
            _prefab = prefab;
            _spawnPosition = spawnPosition;
            _parent =  parent;

            SpawnDelay = 2.3f;
            _pipes = new List<PipePresentation>();
        }

        public void Spawn()
        {
            Vector2 pipePosition = GetRandomPosition();
            PipePresentation pipePresentation = Object.Instantiate(_prefab, pipePosition, Quaternion.identity, _parent);
            pipePresentation.Initialize();
            _pipes.Add(pipePresentation);
        }

        public void Clear()
        {
            _pipes.ForEach(pipe => Object.Destroy(pipe.gameObject));
            _pipes.Clear();
        }

        private Vector2 GetRandomPosition()
        {
            var yPosition = Random.Range(_yPositionMinRange, _yPositionMaxRange);
            var pipePosition = new Vector2(_spawnPosition.x, yPosition);
            return pipePosition;
        }
    }
}