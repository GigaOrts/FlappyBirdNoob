using _Scripts.Core.Hazards;
using _Scripts.Core.PipeLogic;
using UnityEngine;

namespace _Scripts.Core.MonoBehaviours
{
    public class PipePresentation : MonoBehaviour
    {
        private Pipe _pipe;
        
        public void Initialize()
        {
            _pipe = new Pipe(transform);
        }
        
        private void Update()
        {
            _pipe.Move();
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out BirdPresentation bird))
            {
                bird.Die();
            }
        }
    }
}
