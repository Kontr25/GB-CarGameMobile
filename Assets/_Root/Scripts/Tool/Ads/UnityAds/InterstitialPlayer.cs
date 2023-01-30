using UnityEngine.Advertisements;

namespace _Root.Scripts.Tool.Ads.UnityAds
{
    internal sealed class InterstitialPlayer : UnityAdsPlayer
    {
        public InterstitialPlayer(string id) : base(id)
        {
        }

        protected override void OnPlaying()
        {
            Advertisement.Show(Id, this);
        }

        protected override void Load()
        {
            Advertisement.Load(Id, this);
        }
    }
}