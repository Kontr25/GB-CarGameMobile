using Features.Shed.Upgrade;

namespace Game.Car
{
    internal class CarModel : IUpgradable
    {
        private readonly float _defaultSpeed;
        private readonly float _defaultJumpHeight;
        private readonly float _defaultVisibilityRange;
        private readonly float _defaultEndurance;

        public float Speed { get; set; }
        public float JumpHeight { get; set; }
        
        public float Endurance { get; set; }

        public float VisibilityRange { get; set; }


        public CarModel(float speed, float jumpHeight, float visibilityRange, float endurance)
        {
            _defaultSpeed = speed;
            _defaultJumpHeight = jumpHeight;
            _defaultVisibilityRange = visibilityRange;
            _defaultEndurance = endurance;
            Speed = speed;
            JumpHeight = jumpHeight;
            VisibilityRange = visibilityRange;
            Endurance = endurance;
        }


        public void Restore()
        {
            Speed = _defaultSpeed;
            JumpHeight = _defaultJumpHeight;
            VisibilityRange = _defaultVisibilityRange;
            Endurance = _defaultEndurance;
        }
            
    }
}
