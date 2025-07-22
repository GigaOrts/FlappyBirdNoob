using _Scripts.Core.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace _Scripts.Core.BirdLogic
{
    public class BirdPhysics
    {
        private const float JumpForce = 12f;
        private const float MaxUpAngle = 30f;
        private const float MaxDownAngle = -60f;
        private const float MinRotationSpeedFactor = 0.5f;
        private const float MaxRotationSpeedFactor = 5f;

        private float _targetAngle;
        private float _rotationSpeedFactor = 1.5f;

        private Rigidbody2D _rigidbody;
        
        public void Init(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }
        
        public void Jump() 
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }

        public void UpdateRotation()
        {
            if (_rigidbody.velocity.y > 0.1f)
            {
                _rotationSpeedFactor = MaxRotationSpeedFactor;
                _targetAngle = MaxUpAngle;
            }
            else
            {
                _rotationSpeedFactor = MinRotationSpeedFactor;
                _targetAngle = MaxDownAngle;
            }

            var currentZ = _rigidbody.transform.eulerAngles.z;
            var angle = Mathf.LerpAngle(currentZ, _targetAngle, Mathf.Abs(_rigidbody.velocity.y) * Time.deltaTime * _rotationSpeedFactor);
            _rigidbody.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        public void Reset(Vector3 startPosition)
        {
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.angularVelocity = 0;
            _rigidbody.position = startPosition;
            _rigidbody.transform.rotation = Quaternion.identity;
        }

        public void EnablePhysics() => _rigidbody.isKinematic = false;
        public void DisablePhysics() => _rigidbody.isKinematic = true;
    }
}