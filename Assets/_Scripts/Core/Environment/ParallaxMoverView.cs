using UnityEngine;

namespace _Scripts.Core
{
    public class ParallaxMoverView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _speed;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            Vector2 size = _spriteRenderer.size;
            size.x += Time.deltaTime * _speed;
            _spriteRenderer.size = size;
        }
    }
}
