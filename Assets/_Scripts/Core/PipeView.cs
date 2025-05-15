using UnityEngine;

namespace _Scripts.Core
{
    public class PipeView : Hazard
    {
        private Pipe _pipe;
        private Rigidbody2D _body2D;

        private void Awake()
        {
            _pipe = new Pipe();
            _body2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _body2D.velocity = Vector2.left * _pipe.Speed;   
        }
    }
}
