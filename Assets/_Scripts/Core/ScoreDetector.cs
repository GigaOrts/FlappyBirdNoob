using UnityEngine;

namespace _Scripts.Core
{
    public class ScoreDetector : MonoBehaviour
    {
        [SerializeField] private Score _score;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _score.Add(1);
        }
    }
}
