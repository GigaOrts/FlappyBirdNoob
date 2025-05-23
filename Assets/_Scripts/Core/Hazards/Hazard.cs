using UnityEngine;

namespace _Scripts.Core
{
    public class Hazard : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out BirdPresentation bird))
            {
                bird.Die();
            }
        }
    }
}
