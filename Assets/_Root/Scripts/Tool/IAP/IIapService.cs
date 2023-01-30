using UnityEngine.Events;

namespace _Root.Scripts.Tool.IAP
{
    public interface IIapService
    {
        UnityEvent Initialized { get; }
        UnityEvent PurchaseSucceed { get; }
        UnityEvent PurchaceFailed { get; }
        bool IsInitialized { get; }

        void Buy(string id);
        string GetCost(string productID);
        void RestorePurchases();
    }
}