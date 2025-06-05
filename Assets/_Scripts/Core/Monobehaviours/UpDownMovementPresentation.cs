using System.Collections;
using _Scripts.Core.UpDownMovementLogic;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core.MonoBehaviours
{
    public class UpDownMovementPresentation : MonoBehaviour
    {
        private UpDownMovement _upDownMovement;
        private Coroutine _moveCoroutine;

        public void Initialize(UpDownMovement upDownMovement)
        {
            _upDownMovement = upDownMovement;
        }
        
        private void Start()
        {
            StartMoving();
        }

        public void StartMoving()
        {
            _moveCoroutine ??= StartCoroutine(MoveUpDown());
        }

        public void StopMoving()
        {
            if (_moveCoroutine == null) 
                return;
            
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
            _upDownMovement.ResetPosition();
        }
        
        private IEnumerator MoveUpDown()
        {
            while (true)
            {
                _upDownMovement.Move();
                yield return new WaitForFixedUpdate();
            }
        }
    }
}