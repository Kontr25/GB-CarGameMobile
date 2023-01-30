using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
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


        public void Init(UnityAction startGame, UnityAction openSettings, UnityAction showRewardedAds)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(openSettings);
            _buttonRewardedAds.onClick.AddListener(showRewardedAds);
        }


        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
            _buttonRewardedAds.onClick.RemoveAllListeners();
        }

        public void ChangeBG()
        {
            _backGround.sprite = _backgroundSprite;
        }
    }
}
