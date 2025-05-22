using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bird : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _startButton;
        
        private static readonly int Fly = Animator.StringToHash("Fly");
        private static readonly int FlyLoop = Animator.StringToHash("FlyLoop");
        
        private readonly float _maxUpAngle = 30f;
        private readonly float _maxDownAngle = -60f;

        private readonly float _minRotationSpeedFactor = 0.5f;
        private readonly float _maxRotationSpeedFactor = 5f;

        private readonly float _jumpForce = 12;
        private float _rotationSpeedFactor = 1.5f;
        private float _targetAngle;

        public event Action Died;

        private Rigidbody2D _body2D;
        private Animator _animator;
        private Vector3 _startPosition;
        private bool _ready;

        private void Awake()
        {
            _startButton.onClick.AddListener(OnStart);
            _restartButton.onClick.AddListener(OnRestart);
            _body2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _startPosition = transform.position;
            _animator.SetBool(FlyLoop, true);
            Reset();
        }

        private void OnStart()
        {
            _ready = true;
            _body2D.isKinematic = false;
            _animator.SetBool(FlyLoop, false);
            
            Jump();
            AnimateJump();
        }

        private void OnRestart()
        {
            Reset();
            _animator.SetBool(FlyLoop, true);
        }

        private void Reset()
        {
            _ready = false;   
            _body2D.isKinematic = true;
            
            _body2D.velocity = Vector2.zero;
            _body2D.angularVelocity = 0;
            transform.position = _startPosition;
            transform.rotation = Quaternion.identity;
        }

        private void Update()
        {
            if (!_ready)
                return;
            
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
            Died?.Invoke();
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
