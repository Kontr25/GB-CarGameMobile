using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonRewardedAds;
        [SerializeField] private Sprite _backgroundSprite;
        [SerializeField] private Image _backGround;
        [SerializeField] private Button _buttonShed;
        [SerializeField] private Button _buttonReward;
        [SerializeField] private Button _exitGame;


        public void Init(UnityAction startGame, UnityAction openSettings, UnityAction showRewardedAds, UnityAction openShed, 
            UnityAction openDailyReward, UnityAction exitGame)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(openSettings);
            _buttonRewardedAds.onClick.AddListener(showRewardedAds);
            _buttonShed.onClick.AddListener(openShed);
            _buttonReward.onClick.AddListener(openDailyReward);
            _exitGame.onClick.AddListener(exitGame);
        }


        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
            _buttonRewardedAds.onClick.RemoveAllListeners();
            _buttonShed.onClick.RemoveAllListeners();
            _buttonReward.onClick.RemoveAllListeners();
            _exitGame.onClick.RemoveAllListeners();
        }

        public void ChangeBG()
        {
            _backGround.sprite = _backgroundSprite;
        }
    }
}
