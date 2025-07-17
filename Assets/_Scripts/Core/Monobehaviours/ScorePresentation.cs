using _Scripts.Core.ScoreLogic;
using UnityEngine;
using Zenject;

namespace _Scripts.Core.MonoBehaviours
{
    public class ScorePresentation : MonoBehaviour
    {
        private Score _score;

        [Inject]
        public void Construct(Score score)
        {
            _score = score;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _score.Add(1);
        }
    }
}
