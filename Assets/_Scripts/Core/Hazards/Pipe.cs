using UnityEngine;

namespace _Scripts.Core.Hazards
{
    public class Pipe : Hazard
    {
        private readonly float _speed = 2.5f;

        private void Update()
        {
            transform.Translate(Vector2.left * (_speed * Time.deltaTime));   
        }
    }
}
