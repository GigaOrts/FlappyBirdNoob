using UnityEngine;

namespace _Scripts.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdView : MonoBehaviour
    {
        private static readonly int Fly = Animator.StringToHash("Fly");
        
        private Bird _bird;
        
        private Rigidbody2D _body2D;
        private Animator _animator;
        
        private void Awake()
        {
            _bird = new Bird();
            
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
                _bird.SetMaxRotationSpeed();
                _bird.SetMaxTargetAngle();
            }
            else
            {
                _bird.SetMinRotationSpeed();
                _bird.SetMinTargetAngle();
            }  

            var currentAngle = transform.eulerAngles.z;  

            var angle = Mathf.LerpAngle(currentAngle, _bird.TargetAngle, Mathf.Abs(_body2D.velocity.y) * Time.deltaTime * _bird.RotationSpeedFactor);  
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void AnimateJump()
        {
            _animator.SetTrigger(Fly);
        }

        private void Jump()
        {
            _body2D.velocity = Vector2.zero;
            _body2D.AddForce(new Vector2(0, _bird.JumpForce), ForceMode2D.Impulse);
        }
        
        public void Die()
        {
            _bird.Die();
        }
    }
}
