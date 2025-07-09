using System.Collections;
using _Scripts.Core.Hazards;
using UnityEngine;
using Zenject;

namespace _Scripts.Core.MonoBehaviours
{
    public class PipeFactoryPresentation : MonoBehaviour
    {
        private Coroutine _spawnCoroutine;
        private PipeFactory _pipeFactory;
        private float _spawnDelay;

        public void Initialize(PipeFactory pipeFactory)
        {
            _pipeFactory = pipeFactory;
            _spawnDelay = _pipeFactory.SpawnDelay;
        }
        
        [Inject]
        public void Construct(PipeFactory pipeFactory)
        {
            _pipeFactory = pipeFactory;
            _spawnDelay = _pipeFactory.SpawnDelay;
        }
        
        public void StartSpawn()
        {
            _spawnCoroutine = StartCoroutine(SpawnPipes());
        }

        public void StopSpawn()
        {
            _pipeFactory.Clear();
            
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
            }
        }

        private IEnumerator SpawnPipes()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);
                _pipeFactory.Spawn();
            }
        }
    }
}