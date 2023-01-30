using System;
using _Root.Scripts.Tool.IAP.Settings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;
using Product = UnityEngine.Purchasing.Product;

namespace _Root.Scripts.Tool.IAP
{
    internal class IAPService: MonoBehaviour, IStoreListener, IIapService
    {
        [Header("Components")] 
        [SerializeField] private ProductLibrary _productLibrary;
        
        [field: Header("Events")]
        
        [field: SerializeField] public UnityEvent Initialized { get; private set; }
        [field: SerializeField] public UnityEvent PurchaseSucceed { get; private set;  }
        [field: SerializeField] public UnityEvent PurchaceFailed { get; private set;  }
         
        public bool IsInitialized { get; private set; }

        private IExtensionProvider _extensionProvider;
        private PurchaseValidator _purchaseValidator;
        private PurchaseRestorer _purchaseRestorer;
        private IStoreController _controller;

        private void Awake()
        {
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            StandardPurchasingModule purchasingModule = StandardPurchasingModule.Instance();
            ConfigurationBuilder builder = ConfigurationBuilder.Instance(purchasingModule);

            foreach (Settings.Product product in _productLibrary.Products)
            {
                builder.AddProduct(product.Id, product.ProductType);
            }
            
            Log("Product initialized");
            UnityPurchasing.Initialize(this, builder);
        }

        void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensionProvider)
        {
            IsInitialized = true;
            _controller = controller;
            _extensionProvider = extensionProvider;
            _purchaseValidator = new PurchaseValidator();
            _purchaseRestorer = new PurchaseRestorer(_extensionProvider);
            
            Log("Initialized");
            Initialized?.Invoke();
        }

        void IStoreListener.OnInitializeFailed(InitializationFailureReason error)
        {
            IsInitialized = false;
            Error("Initialization failed");
        }
        

        PurchaseProcessingResult IStoreListener.ProcessPurchase(PurchaseEventArgs args)
        {
            if (_purchaseValidator.Validate(args))
            {
                PurchaseSucceed.Invoke();
            }
            else
            {
                OnPurchaseFailed(args.purchasedProduct.definition.id, "NonValid");
            }

            return PurchaseProcessingResult.Complete;
        }

        void IStoreListener.OnPurchaseFailed(UnityEngine.Purchasing.Product product, PurchaseFailureReason failureReason)
        {
            OnPurchaseFailed(product.definition.id, failureReason.ToString());
        }

        private void OnPurchaseFailed(string productId, string reason)
        {
            Error($"Failed {productId}: {reason}");
            PurchaceFailed?.Invoke();
        }
        
        public void Buy(string id)
        {
            if (IsInitialized)
            {
                _controller.InitiatePurchase(id);
            }
            else
            {
                Error($"Buy {id} FAIL. Nit initialized.");
            }
        }

        public string GetCost(string productID)
        {
            UnityEngine.Purchasing.Product product = _controller.products.WithID(productID);
            return product != null ? product.metadata.localizedPriceString : "N/A";
        }

        public void RestorePurchases()
        {
            if (IsInitialized)
            {
                _purchaseRestorer.Restore();
            }
            else
            {
                Error("RestorePurchases FAIL. Not initialized");
            }
        }
        
        private void Log(string message) => Debug.Log(WrapMessage(message));
        private void Error(string message) => Debug.LogError(WrapMessage(message));
        private string WrapMessage(string message) => $"[{GetType().Name}] {message}";
    }
}