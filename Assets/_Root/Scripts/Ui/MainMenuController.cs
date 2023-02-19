using _Root.Scripts.Tool.Ads.UnityAds;
using Profile;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        private readonly UnityAdsService _adsService;


        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, UnityAdsService adsService)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _adsService = adsService;
            _view.Init(StartGame, OpenSettings, ShowRewarderAds, OpenShed, OpenReward, ExitGame);
        }


        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame() =>
            _profilePlayer.CurrentState.Value = GameState.Game;
        
        private void OpenSettings() =>
            _profilePlayer.CurrentState.Value = GameState.Settings;

        private void ShowRewarderAds()
        { 
            if (_adsService.isInitialized) OnAdsInitialized();
            else _adsService.Initialized.AddListener(OnAdsInitialized);
        }
        
        private void OpenShed() =>
            _profilePlayer.CurrentState.Value = GameState.Shed;
        
        private void OnAdsInitialized() => _adsService.RewardedPlayer.Play();
        
        private void OpenReward() =>
            _profilePlayer.CurrentState.Value = GameState.Reward;

        private void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
