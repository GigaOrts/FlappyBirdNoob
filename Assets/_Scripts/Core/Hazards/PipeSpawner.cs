using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core.Hazards
{
    public class PipeSpawner : MonoBehaviour
    {
        private readonly float _spawnDelay = 2.3f;
        private List<Pipe> _pipes;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _startButton;
        [SerializeField] private Pipe _pipePrefab;
        [SerializeField] private Transform _spawnPoint;

        private Vector2 _spawnPosition;
        private readonly float _yPositionMinRange = -1.5f;
        private readonly float _yPositionMaxRange = 3.5f;
        
        private Coroutine _spawnCoroutine;

        private void Awake()
        {
            _startButton.onClick.AddListener(OnStart);
            _restartButton.onClick.AddListener(OnRestart);
            
            _pipes = new List<Pipe>();
            _spawnPosition = _spawnPoint.position;
        }

        private void OnStart()
        {
            StartSpawn();
        }

        private void OnRestart()
        {
            Clear();
            StopSpawn();
        }

        private void StartSpawn()
        {
            _spawnCoroutine = StartCoroutine(SpawnPipes());
        }

        private void StopSpawn()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
            }
        }

        private void Clear()
        {
            _pipes.ForEach(pipe => Destroy(pipe.gameObject));
            _pipes.Clear();
        }

        private IEnumerator SpawnPipes()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);
                Vector2 pipePosition = GetRandomPosition();
                Pipe pipe = Instantiate(_pipePrefab, pipePosition, Quaternion.identity, transform);
                _pipes.Add(pipe);
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