using Features.Rewards.Currency;
using Rewards;
using Tool;
using UnityEngine;

namespace _Root.Scripts.Rewards
{
    internal class CurrencyController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Rewards/CurrencyView");
        private readonly CurrencyModel _model;
        private readonly CurrencyView _view;

        public CurrencyController(CurrencyModel currencyModel, Transform placeForUi)
        {
            _model = currencyModel;

            _view = LoadView(placeForUi);
            _view.Init(_model.Wood, _model.Diamond, _model.Metal, _model.Food, _model.Money);

            Subscribe(_model);
        }

        protected override void OnDispose()
        {
            Unsubscribe(_model);
            base.OnDispose();
        }


        private CurrencyView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<CurrencyView>();
        }


        private void Subscribe(CurrencyModel model)
        {
            model.WoodChanged += OnWoodChanged;
            model.DiamondChanged += OnDiamondChanged;
            model.MetalChanged += OnMetalChanged;
            model.FoodChanged += OnFoodChanged;
            model.MoneyChanged += OnMoneyChanged;
        }

        private void Unsubscribe(CurrencyModel model)
        {
            model.WoodChanged -= OnWoodChanged;
            model.DiamondChanged -= OnDiamondChanged;
            model.MetalChanged -= OnMetalChanged;
            model.FoodChanged -= OnFoodChanged;
            model.MoneyChanged -= OnMoneyChanged;
        }

        private void OnWoodChanged() => _view.SetWood(_model.Wood);
        private void OnDiamondChanged() => _view.SetDiamond(_model.Diamond);
        private void OnMetalChanged() => _view.SetMetal(_model.Metal);
        private void OnFoodChanged() => _view.SetFood(_model.Food);
        private void OnMoneyChanged() => _view.SetMoney(_model.Money);
    }
}