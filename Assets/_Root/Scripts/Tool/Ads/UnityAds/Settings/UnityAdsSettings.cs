using UnityEngine;

namespace _Root.Scripts.Tool.Ads.UnityAds.Settings
{
    [CreateAssetMenu (fileName = nameof(UnityAdsSettings), menuName = "Settings/Ads" + nameof(UnityAdsSettings))]
    internal class UnityAdsSettings : ScriptableObject
    {
        [Header("Game ID")] 
        [SerializeField] private string _androidGameId;
        
        [field: Header("Players")]
        [field: SerializeField] public AdsPlayerSettings Interstitial { get; private set; }
        [field: SerializeField] public AdsPlayerSettings Rewarded { get; private set; }
        [field: SerializeField] public AdsPlayerSettings Banner { get; private set; }

        [field: Header("Settings")]
        [field: SerializeField] public bool TestMode { get; private set; } = true;
        [field: SerializeField] public bool EnablePerPlacementMode { get; private set; } = true;

        public string GameID => _androidGameId;
    }
}