using UnityEngine;

namespace _Scripts.Core.Hazards
{
    public class Pipe : Hazard
    {
        private readonly float _speed = 2.5f;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = Vector2.left * _speed;   
        }
    }
}
