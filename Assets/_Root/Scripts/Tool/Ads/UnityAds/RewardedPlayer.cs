using UnityEngine;
using UnityEngine.Advertisements;

namespace _Root.Scripts.Tool.Ads.UnityAds
{
    public class RewardedPlayer : UnityAdsPlayer
    {
        public RewardedPlayer(string id) : base(id)
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