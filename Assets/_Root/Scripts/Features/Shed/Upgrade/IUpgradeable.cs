namespace Features.Shed.Upgrade
{
    internal interface IUpgradable
    {
        float Speed { get; set; }
        float JumpHeight { get; set; }
        
        float Endurance { get; set; }
        
        float VisibilityRange { get; set; }
        void Restore();
    }
}
