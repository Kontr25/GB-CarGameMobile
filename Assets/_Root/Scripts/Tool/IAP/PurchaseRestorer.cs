using UnityEngine;
using UnityEngine.Purchasing;

namespace _Root.Scripts.Tool.IAP
{
    internal class PurchaseRestorer
    {
        private readonly IExtensionProvider _extensionProvider;

        public PurchaseRestorer(IExtensionProvider extensionProvider) =>
            _extensionProvider = extensionProvider;

        public void Restore()
        {
            Log("RestorePurchases started ...");

            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    _extensionProvider.GetExtension<IGooglePlayStoreExtensions>().RestoreTransactions(OnRestoredTransactopns);
                    break;
                default:
                    Log("Restore FAIL");
                    break;
            }
        }

        private void OnRestoredTransactopns(bool result) =>
            Log("RestorePurchases continuing: " + result + ". if no further message ....");
        
        private void Log(string message) => Debug.Log(WrapMessage(message));
        private void Error(string message) => Debug.LogError(WrapMessage(message));
        private string WrapMessage(string message) => $"[{GetType().Name}] {message}";
    }
}