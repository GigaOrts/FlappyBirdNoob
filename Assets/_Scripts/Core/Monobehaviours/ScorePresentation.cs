using _Scripts.Core.ScoreLogic;
using UnityEngine;

namespace _Scripts.Core.MonoBehaviours
{
    public class ScorePresentation : MonoBehaviour
    {
        private Score _score;

        public void Initialize(Score score)
        {
            _score = score;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _score.Add(1);
        }
    }
}
