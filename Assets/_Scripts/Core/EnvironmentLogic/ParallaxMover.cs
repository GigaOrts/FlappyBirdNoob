using UnityEngine;

namespace _Scripts.Core.EnvironmentLogic
{
    using Zenject;

    public class ParallaxMover
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly float _speed;
        
        [Inject]
        public ParallaxMover(SpriteRenderer spriteRenderer, float speed)
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
