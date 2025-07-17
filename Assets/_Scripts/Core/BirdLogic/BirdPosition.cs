using UnityEngine;
using Zenject;

namespace _Scripts.Core
{
    public class BirdPosition : MonoBehaviour
    {
        public Transform startPosition;
        
        [Inject]
        public void Construct(BirdLifecycle lifecycle)
        {
            lifecycle.SetStartPosition(startPosition.position);
        }
    }
}