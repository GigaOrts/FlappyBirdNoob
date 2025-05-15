namespace _Scripts.Core
{
    public class Bird
    {
        private readonly float _maxUpAngle = 30f;
        private readonly float _maxDownAngle = -60f;

        private readonly float _minRotationSpeedFactor = 0.5f;
        private readonly float _maxRotationSpeedFactor = 5f;

        public float JumpForce { get; } = 9;
        public float RotationSpeedFactor { get; private set; } = 1.5f;
        public float TargetAngle  { get; private set; }

        public void SetMaxTargetAngle()
        {
            TargetAngle = _maxUpAngle;
        }
        
        public void SetMinTargetAngle()
        {
            TargetAngle = _maxDownAngle;
        }

        public void SetMaxRotationSpeed()
        {
            RotationSpeedFactor = _maxRotationSpeedFactor;
        }
        
        public void SetMinRotationSpeed()
        {
            RotationSpeedFactor = _minRotationSpeedFactor;
        }
        
        public void Die()
        {
            throw new System.NotImplementedException();
        }
    }
}