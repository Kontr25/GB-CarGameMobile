namespace Features.Shed.Upgrade
{
    internal class VisibilityRangeUpgradeHandler: IUpgradeHandler
    {
        private readonly float _visibilityRange;

        public VisibilityRangeUpgradeHandler(float visibilityRange) =>
            _visibilityRange = visibilityRange;

        public void Upgrade(IUpgradable upgradable) =>
            upgradable.VisibilityRange += _visibilityRange;
    }
}