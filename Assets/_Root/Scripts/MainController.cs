using _Root.Scripts.Tool.Ads.UnityAds;
using _Root.Scripts.Tool.Analytics;
using Ui;
using Game;
using Profile;
using UnityEngine;

internal class MainController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private SettingsWindowController _settingsWindowController;
    private AnalyticsManager _analyticsManager;
    private UnityAdsService _adsService;


    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, AnalyticsManager analyticsManager, UnityAdsService adsService)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _analyticsManager = analyticsManager;
        _adsService = adsService;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _settingsWindowController?.Dispose();

        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer, _adsService);
                _settingsWindowController?.Dispose();
                _gameController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_profilePlayer);
                _settingsWindowController?.Dispose();
                _mainMenuController?.Dispose();
                _analyticsManager.SendGameStartedEvent();
                break;
            case GameState.Settings:
                _settingsWindowController = new SettingsWindowController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                _mainMenuController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _settingsWindowController?.Dispose();
                break;
        }
    }
}
