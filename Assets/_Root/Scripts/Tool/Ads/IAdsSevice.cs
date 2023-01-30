using UnityEngine.Events;

namespace _Root.Scripts.Tool.Ads
{
    internal interface IAdsSevice
    {
        IAdsPlayer InterstitialPlayer { get; }
        IAdsPlayer RewardedPlayer { get; }
        IAdsPlayer BannerPlayer { get; }
        UnityEvent Initialized { get; }
        bool isInitialized { get; }
    }
}