using UnityEngine;

namespace _Scripts.Core.Monobehaviours
{
    public class OnTriggerEnterDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }
    }
}
