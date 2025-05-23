using UnityEngine;

namespace _Scripts.Core.Environment
{
    public class ParallaxMover
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly float _speed;

        public ParallaxMover(SpriteRenderer spriteRenderer, float speed)
        {
            _spriteRenderer = spriteRenderer;
            _speed = speed;
        }
        
        public void Move(float dt)
        {
            Vector2 size = _spriteRenderer.size;
            size.x += _speed * dt;
            _spriteRenderer.size = size;
        }
    }
}
