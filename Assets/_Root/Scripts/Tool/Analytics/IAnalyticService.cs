using System.Collections.Generic;

namespace _Root.Scripts.Tool.Analytics
{
    internal interface IAnalyticService
    {
        void SendEvent(string eventName);
        void SendEvent(string eventName, Dictionary<string, object> evendData);
    }
}