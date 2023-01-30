using System.Collections.Generic;

namespace _Root.Scripts.Tool.Analytics.UnityAnalytics
{
    public class UnityAnalyticsService : IAnalyticService
    {
        public void SendEvent(string eventName)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(eventName);
        }

        public void SendEvent(string eventName, Dictionary<string, object> evendData)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(eventName, evendData);
        }
    }
}