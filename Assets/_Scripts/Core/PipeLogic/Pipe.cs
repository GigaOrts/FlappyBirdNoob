using UnityEngine;

namespace _Scripts.Core.PipeLogic
{
    public class Pipe
    {
        private readonly float _speed = 2.5f;
        private readonly Transform _transform;

        public Pipe(Transform transform)
        {
            _transform = transform;
        }
        
        public void Move()
        {
            _transform.Translate(Vector2.left * (_speed * Time.deltaTime));   
        }
    }
}