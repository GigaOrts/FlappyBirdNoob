using System.Collections;
using UnityEngine;

namespace _Scripts.Core
{
    public class PipeSpawnerView : MonoBehaviour
    {
        private PipeSpawner _pipeSpawner;
        
        [SerializeField] private PipeView _pipeViewPrefab;
        [SerializeField] private Transform _spawnPoint;

        private Vector2 _spawnPosition;
        private readonly float _yPositionMinRange = -1.5f;
        private readonly float _yPositionMaxRange = 3.5f;
        
        private Coroutine _spawnCoroutine;

        private void Awake()
        {
            _pipeSpawner = new PipeSpawner();
            _spawnPosition = _spawnPoint.position;
        }

        public void StartSpawn()
        {
            Clear();
            _spawnCoroutine = StartCoroutine(SpawnPipes());
        }

        public void StopSpawn()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
            }
        }

        private void Clear()
        {
            _pipeSpawner.Pipes.ForEach(pipe => Destroy(pipe.gameObject));
            _pipeSpawner.Pipes.Clear();
        }

        private IEnumerator SpawnPipes()
        {
            while (true)
            {
                yield return new WaitForSeconds(_pipeSpawner.SpawnDelay);
                Vector2 pipePosition = GetRandomPosition();
                PipeView pipeView = Instantiate(_pipeViewPrefab, pipePosition, Quaternion.identity, transform);
                _pipeSpawner.Pipes.Add(pipeView);
            }
        }

        private Vector2 GetRandomPosition()
        {
            var yPosition = Random.Range(_yPositionMinRange, _yPositionMaxRange);
            var pipePosition = new Vector2(_spawnPosition.x, yPosition);
            return pipePosition;
        }
    }
}