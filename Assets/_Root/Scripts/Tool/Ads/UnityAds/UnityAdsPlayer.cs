using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace _Root.Scripts.Tool.Ads.UnityAds
{
    public abstract class UnityAdsPlayer : IAdsPlayer, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        public event Action Started;
        public event Action Finished;
        public event Action Failed;
        public event Action Skipped;
        public event Action BecomeReady;
        protected readonly string Id;

        protected UnityAdsPlayer(string id)
        {
            Id = id;
            //Advertisement.Load(Id,this);
            //Advertisement.Show(Id,this);
        }
        public void Play()
        {
            Load();
            OnPlaying();
            Load();
        }

        protected abstract void OnPlaying();
        protected abstract void Load();

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            Error($"Error {message}");
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            if (IsIdMy(placementId) == false)
            {
                return;
            }
            Log("Started");
            Started?.Invoke();
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            Log("Clicked");
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (IsIdMy(placementId) == false)
            {
                return;
            }

            switch (showCompletionState)
            {
                case UnityAdsShowCompletionState.COMPLETED:
                    Log("Finished");
                    Finished?.Invoke();
                    break;
                case UnityAdsShowCompletionState.SKIPPED:
                    Log("Skipped");
                    Skipped?.Invoke();
                    break;
                case UnityAdsShowCompletionState.UNKNOWN:
                    Log("Failed");
                    Failed?.Invoke();
                    break;
            }
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            if (IsIdMy(placementId) == false)
            {
                return;
            }
            Log($"Ready {Id} ");
            BecomeReady?.Invoke();
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            Error($"Error {message}");
        }

        private void Log(string message) => Debug.Log(WrapMessage(message));
        private bool IsIdMy(string id) => Id == id;
        private void Error(string message) => Debug.LogError(WrapMessage(message));
        private string WrapMessage(string message) => $"[{GetType().Name}] {message}";
    }
}