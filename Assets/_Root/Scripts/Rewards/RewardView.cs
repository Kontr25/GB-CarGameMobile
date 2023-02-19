using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewards
{
    internal class RewardView : MonoBehaviour
    {
        private const string CurrentSlotInActiveKey = nameof(CurrentSlotInActiveKey);
        private const string TimeGetRewardKey = nameof(TimeGetRewardKey);
        private const int _daysInWeek = 7;
        private float _timeDeadline;
        private int _curretWeeklyRewardNumber = 0;
        private int _curretDailyRewardNumber = 0;

        [field: Header("Settings Time Get Reward")]
        [field: SerializeField] public float TimeCooldown { get; private set; } = 86400;

        [field: Header("Settings Rewards")]
        [field: SerializeField] public List<Reward> DaylyRewards { get; private set; }
        [field: SerializeField] public List<Reward> WeeklyRewards { get; private set; }

        [field: Header("Ui Elements")]
        [field: SerializeField] public TMP_Text TimerNewReward { get; private set; }
        [field: SerializeField] public Transform MountRootSlotsReward { get; private set; }
        [field: SerializeField] public ContainerSlotRewardView ContainerSlotRewardPrefab { get; private set; }
        [field: SerializeField] public Button GetRewardButton { get; private set; }
        [field: SerializeField] public Button ResetButton { get; private set; }
        [field: SerializeField] public Button CloseButton { get; private set; }


        private void Start()
        {
            _timeDeadline = TimeCooldown * 3;
        }

        public int CurrentSlotInActive
        {
            get => PlayerPrefs.GetInt(CurrentSlotInActiveKey);
            set => PlayerPrefs.SetInt(CurrentSlotInActiveKey, value);
        }

        public DateTime? TimeGetReward
        {
            get
            {
                string data = PlayerPrefs.GetString(TimeGetRewardKey);
                return !string.IsNullOrEmpty(data) ? DateTime.Parse(data) : null;
            }
            set
            {
                if (value != null)
                    PlayerPrefs.SetString(TimeGetRewardKey, value.ToString());
                else
                    PlayerPrefs.DeleteKey(TimeGetRewardKey);
            }
        }

        public Reward WeeklyReward
        {
            get
            {
                if (_curretWeeklyRewardNumber <= WeeklyRewards.Count - 1)
                {
                    _curretWeeklyRewardNumber += 1;
                }
                else
                {
                    _curretWeeklyRewardNumber = 1;
                }
                return WeeklyRewards[_curretWeeklyRewardNumber - 1];
            }
        }
        
        public Reward DaylyReward
        {
            get
            {
                if (_curretDailyRewardNumber <= DaylyRewards.Count - 1)
                {
                    _curretDailyRewardNumber += 1;
                }
                else
                {
                    _curretDailyRewardNumber = 1;
                }
                return DaylyRewards[_curretDailyRewardNumber - 1];
            }
        }

        public float TimeDeadline
        {
            get => _timeDeadline;
            set => _timeDeadline = value;
        }

        public static int DaysInWeek => _daysInWeek;
    }
}
