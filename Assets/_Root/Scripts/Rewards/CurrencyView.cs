using System.Collections.Generic;
using UnityEngine;

namespace Rewards
{
    internal class CurrencyView : MonoBehaviour
    {
        [SerializeField] private CurrencySlotView _currencyWood;
        [SerializeField] private CurrencySlotView _currentDiamond;
        [SerializeField] private CurrencySlotView _currentMetal;
        [SerializeField] private CurrencySlotView _currentFood;
        [SerializeField] private CurrencySlotView _currentMoney;


        public void Init(int woodCount, int diamondCount, int metalCount, int foodCount, int moneyCount)
        {
            SetWood(woodCount);
            SetDiamond(diamondCount);
            SetMetal(metalCount);
            SetFood(foodCount);
            SetMoney(moneyCount);
        }

        public void SetWood(int value) => _currencyWood.SetData(value);
        public void SetDiamond(int value) => _currentDiamond.SetData(value);
        public void SetMetal(int value) => _currentMetal.SetData(value);
        public void SetFood(int value) => _currentFood.SetData(value);
        public void SetMoney(int value) => _currentMoney.SetData(value);
    }
}
