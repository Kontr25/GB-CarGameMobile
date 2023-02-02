namespace Features.Shed.Upgrade
{
    internal class EnduranceUpgradeHandler : IUpgradeHandler
    {
        private readonly float _endurance;

        public EnduranceUpgradeHandler(float endurance) =>
            _endurance = endurance;

        public void Upgrade(IUpgradable upgradable) =>
            upgradable.Endurance += _endurance;
    }
}