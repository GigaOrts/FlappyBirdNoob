using UnityEngine;

namespace _Scripts.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bird : MonoBehaviour
    {
        private static readonly int Fly = Animator.StringToHash("Fly");
        
        private readonly float _maxUpAngle = 30f;
        private readonly float _maxDownAngle = -60f;

        private readonly float _minRotationSpeedFactor = 0.5f;
        private readonly float _maxRotationSpeedFactor = 5f;

        private readonly float _jumpForce = 9;
        private float _rotationSpeedFactor = 1.5f;
        private float _targetAngle;

        private Rigidbody2D _body2D;
        private Animator _animator;
        
        private void Awake()
        {
            _body2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
                AnimateJump();
            }

            Rotate();
        }

        private void Rotate()
        {
            if (_body2D.velocity.y > 0.1f)
            {
                SetMaxRotationSpeed();
                SetMaxTargetAngle();
            }
            else
            {
                SetMinRotationSpeed();
                SetMinTargetAngle();
            }  

            var currentAngle = transform.eulerAngles.z;  

            var angle = Mathf.LerpAngle(currentAngle, _targetAngle, Mathf.Abs(_body2D.velocity.y) * Time.deltaTime * _rotationSpeedFactor);  
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void AnimateJump()
        {
            _animator.SetTrigger(Fly);
        }

        private void Jump()
        {
            _body2D.velocity = Vector2.zero;
            _body2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
        
        public void Die()
        {
            
        }
        
        private void SetMaxTargetAngle()
        {
            _targetAngle = _maxUpAngle;
        }

        private void SetMinTargetAngle()
        {
            _targetAngle = _maxDownAngle;
        }

        private void SetMaxRotationSpeed()
        {
            _rotationSpeedFactor = _maxRotationSpeedFactor;
        }

        private void SetMinRotationSpeed()
        {
            _rotationSpeedFactor = _minRotationSpeedFactor;
        }
    }
}
