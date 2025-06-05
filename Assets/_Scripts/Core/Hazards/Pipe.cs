using UnityEngine;

namespace _Scripts.Core.Hazards
{
    public class Pipe : MonoBehaviour
    {
        private readonly float _speed = 2.5f;

        private void Update()
        {
            transform.Translate(Vector2.left * (_speed * Time.deltaTime));   
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
