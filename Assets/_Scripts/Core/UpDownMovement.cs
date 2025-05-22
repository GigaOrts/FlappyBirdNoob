using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core
{
    public class UpDownMovement : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _startButton;
        
        public float _amplitude = 1f; 
        public float _speed = 1f;

        private Rigidbody2D _rb;
        private Vector2 _startPosition;
        private Coroutine _moveCoroutine;

        void Awake()
        {
            _startButton.onClick.AddListener(StopMoving);
            _restartButton.onClick.AddListener(StartMoving);
            
            _rb = GetComponent<Rigidbody2D>();
            _startPosition = _rb.position;
        }

        private void Start()
        {
            StartMoving();
        }

        private void StartMoving()
        {
            if (_moveCoroutine == null)
            {
                _moveCoroutine = StartCoroutine(MoveUpDown());
            }
        }

        private void StopMoving()
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
                _moveCoroutine = null;
                _rb.MovePosition(_startPosition);
            }
        }

        private IEnumerator MoveUpDown()
        {
            float elapsedTime = 0f;
            while (true)
            {
                elapsedTime += Time.fixedDeltaTime * _speed;
                float yOffset = Mathf.Sin(elapsedTime) * _amplitude;
                Vector2 newPos = _startPosition + new Vector2(0, yOffset);
                _rb.MovePosition(newPos);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}