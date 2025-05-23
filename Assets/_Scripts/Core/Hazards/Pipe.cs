using UnityEngine;

namespace _Scripts.Core
{
    public class Pipe : Hazard
    {
        private readonly float _speed = 2.5f;
        private Rigidbody2D _body2D;

        private void Awake()
        {
            _body2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _body2D.velocity = Vector2.left * _speed;   
        }
    }
}
