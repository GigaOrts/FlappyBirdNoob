using UnityEngine;

namespace _Scripts.Core.Environment
{
    public class OnTriggerEnterDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }
    }
}
