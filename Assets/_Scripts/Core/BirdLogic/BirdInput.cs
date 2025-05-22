using UnityEngine;

namespace _Scripts.Core.BirdLogic
{
    public class BirdInput
    {
        public bool JumpPressed() => Input.GetMouseButtonDown(0);
    }
}