using System;
using UnityEngine;

namespace _Root.Scripts.Tool.Ads.UnityAds.Settings
{
    [Serializable]
    internal class AdsPlayerSettings
    {
        [field: SerializeField] public  bool Enabled { get; private set; }
        [SerializeField] private string _androidId;

        public string Id => _androidId;
    }
}