using TMPro;
using UnityEngine;

namespace Rewards
{
    internal class CurrencySlotView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;
        [SerializeField] private RewardType _rewardType;

        public RewardType Type => _rewardType;


        public void SetData(int count) =>
            _count.text = count.ToString();
    }
}
