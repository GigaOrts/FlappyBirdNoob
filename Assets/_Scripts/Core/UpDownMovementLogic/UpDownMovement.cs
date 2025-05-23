using UnityEngine;

namespace _Scripts.Core.UpDownMovementLogic
{
    public class UpDownMovement
    {
        private const float Amplitude = 0.25f;
        private const float Speed = 6f;
        private float _elapsedTime = 0f;

        private readonly Rigidbody2D _rigidbody;
        private readonly Vector2 _startPosition;

        public UpDownMovement(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
            _startPosition = _rigidbody.position;
        }

        public void ResetPosition()
        {
            _elapsedTime = 0f;
            _rigidbody.MovePosition(_startPosition);
        }

        public void Move()
        {
            _elapsedTime += Time.fixedDeltaTime * Speed;
            float yOffset = Mathf.Sin(_elapsedTime) * Amplitude;
            Vector2 newPos = _startPosition + new Vector2(0, yOffset);
            _rigidbody.MovePosition(newPos);
        }
    }
}