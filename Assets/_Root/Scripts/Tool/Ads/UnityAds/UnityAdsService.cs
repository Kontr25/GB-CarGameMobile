using System;
using _Root.Scripts.Tool.Ads.UnityAds.Settings;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

namespace _Root.Scripts.Tool.Ads.UnityAds
{
    internal class UnityAdsService : MonoBehaviour, IUnityAdsInitializationListener, IAdsSevice
    {
        [Header("Components")] 
        [SerializeField] private UnityAdsSettings _settings;
        
        [field: Header("Events")]
        [field: SerializeField] public UnityEvent Initialized { get; private set; }
        
        public void OnInitializationComplete()
        {
            Log("Initialization complete");
            Initialized?.Invoke();
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Error($"Initialization failed: {error.ToString()} - {message}");
        }

        public IAdsPlayer InterstitialPlayer { get; private set; }
        public IAdsPlayer RewardedPlayer { get;  private set; }
        public IAdsPlayer BannerPlayer { get;  private set; }
        public bool isInitialized => Advertisement.isInitialized;

        private void Awake()
        {
            InitializedAds();
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            InterstitialPlayer = CreateInterstitial();
            RewardedPlayer = CreateRewarded();
            BannerPlayer = CreateBanner();
        }

        private IAdsPlayer CreateBanner() =>
            new StubPlayer("");

        private IAdsPlayer CreateRewarded() =>
            _settings.Rewarded.Enabled
                ? new RewardedPlayer(_settings.Rewarded.Id)
                : new StubPlayer("");

        private IAdsPlayer CreateInterstitial() =>
            _settings.Interstitial.Enabled
                ? new InterstitialPlayer(_settings.Interstitial.Id)
                : new StubPlayer("");

        private void InitializedAds()
        {
            Advertisement.Initialize(
                _settings.GameID,
                _settings.TestMode,
                this);
        }
        
        private void Log(string message) => Debug.Log(WrapMessage(message));
        private void Error(string message) => Debug.LogError(WrapMessage(message));
        private string WrapMessage(string message) => $"[{GetType().Name}] {message}";
    }
}