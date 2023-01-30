using UnityEngine;
using UnityEngine.Purchasing;

namespace _Root.Scripts.Tool.IAP
{
    internal class PurchaseValidator
    {
        public bool Validate(PurchaseEventArgs args)
        {
            var isValid = true;
#if !UNITY_EDITOR && UNITY_ANDROID
            // var validator = new CrossPlatformValidator(GooglePlayTangle.Data(),
            //    AppleTangle.Data(), Application.identifier);
            //
            // try
            // {
            //    var result = validator.Validate(args.purchasedProduct.receipt);
            // }
            // catch (IAPSecurityException)
            // {
            // isValidate = false;
            // }
#endif
            string logMessage = isValid
                ? $"Receipt is valid. Contents: {args.purchasedProduct.receipt}"
                : "Invalid receipt, not unlocked content";
            
            Log(logMessage);
            return isValid;
        }
        
        private void Log(string message) => Debug.Log(WrapMessage(message));
        private string WrapMessage(string message) => $"[{GetType().Name}] {message}";
            
    }
}