using UnityEngine;

namespace _Scripts.Core.EnvironmentLogic
{
    using Zenject;

    public class GroundParallaxMover
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly float _speed;
        
        [Inject]
        public GroundParallaxMover(SpriteRenderer spriteRenderer, float speed)
        {
            _spriteRenderer = spriteRenderer;
            _speed = speed;
        }
        
        public void Move()
        {
            Vector2 size = _spriteRenderer.size;
            size.x += _speed * Time.deltaTime;
            _spriteRenderer.size = size;
        }
    }
}
