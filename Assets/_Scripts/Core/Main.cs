using UnityEngine;

namespace _Scripts.Core
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private PipeSpawnerView _pipeSpawner;

        private void Start()
        {
            _pipeSpawner.StartSpawn();
        }
    }
}
