using System;
using System.Collections.Generic;
using _Root.Scripts.Tool.Analytics.UnityAnalytics;
using UnityEngine;

namespace _Root.Scripts.Tool.Analytics
{
    internal class AnalyticsManager : MonoBehaviour
    {
        private IAnalyticService[] _services;

        private void Awake()
        {
            _services = new IAnalyticService[]
            {
                new UnityAnalyticsService()
            };
        }

        public void SendGameStartedEvent()
        {
            SendEvent("GameStarted");
            Debug.Log("GameStarted");
        }

        private void SendEvent(string eventName)
        {
            foreach (IAnalyticService service in _services)
            {
                service.SendEvent(eventName);
            }
        }
        
        private void SendEvent(string eventName, Dictionary<string, object> eventData)
        {
            foreach (IAnalyticService service in _services)
            {
                service.SendEvent(eventName, eventData);
            }
        }
    }
}