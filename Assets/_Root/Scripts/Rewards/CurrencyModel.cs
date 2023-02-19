using System;
using UnityEngine;

namespace Features.Rewards.Currency
{
    internal class CurrencyModel
    {
        public event Action WoodChanged;
        public event Action DiamondChanged;
        public event Action MetalChanged;
        public event Action FoodChanged;
        public event Action MoneyChanged;

        private const string WoodKey = nameof(WoodKey);
        private const string DiamondKey = nameof(DiamondKey);
        private const string MetalKey = nameof(MetalKey);
        private const string FoodKey = nameof(FoodKey);
        private const string MoneyKey = nameof(MoneyKey);

        public int Wood
        {
            get => PlayerPrefs.GetInt(WoodKey, 0);
            set => SetValue(WoodKey, Wood, value, WoodChanged);
        }

        public int Diamond
        {
            get => PlayerPrefs.GetInt(DiamondKey, 0);
            set => SetValue(DiamondKey, Diamond, value, DiamondChanged);
        }
        
        public int Metal
        {
            get => PlayerPrefs.GetInt(MetalKey, 0);
            set => SetValue(MetalKey, Metal, value, MetalChanged);
        }
        public int Food
        {
            get => PlayerPrefs.GetInt(FoodKey, 0);
            set => SetValue(FoodKey, Food, value, FoodChanged);
        }
        public int Money
        {
            get => PlayerPrefs.GetInt(MoneyKey, 0);
            set => SetValue(MoneyKey, Money, value, MoneyChanged);
        }

        private void SetValue(string valueKey, int oldValue, int newValue, Action changedAction)
        {
            if (oldValue == newValue)
                return;

            PlayerPrefs.SetInt(valueKey, newValue);
            changedAction?.Invoke();
        }
    }
}