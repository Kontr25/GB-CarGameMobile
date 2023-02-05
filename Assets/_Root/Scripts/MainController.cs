using _Root.Scripts.Tool.Ads.UnityAds;
using _Root.Scripts.Tool.Analytics;
using Features.Inventory;
using Features.Shed;
using Features.Shed.Upgrade;
using Ui;
using Game;
using Profile;
using Tool;
using UnityEngine;

internal class MainController : BaseController
{
    
    private readonly ResourcePath _dataSourcePath = new ResourcePath("Configs/Shed/UpgradeItemConfigDataSource");
    
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    private SettingsMenuController _settingsMenuController;
    private ShedController _shedController;
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private SettingsWindowController _settingsWindowController;
    private AnalyticsManager _analyticsManager;
    private UnityAdsService _adsService;
    private InventoryController _inventoryController;


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
        DisposeControllers();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        DisposeControllers();
        
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer, _adsService);
                break;
            case GameState.Game:
                _gameController = new GameController(_placeForUi, _profilePlayer);
                _analyticsManager.SendGameStartedEvent();
                break;
            case GameState.Settings:
                _settingsWindowController = new SettingsWindowController(_placeForUi, _profilePlayer);
                break;
            case GameState.Shed:
                _shedController = new ShedController(_placeForUi, _profilePlayer, CreateRepository(), CreateInventoryController(_placeForUi));
                break;
        }
    }

    private void DisposeControllers()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _settingsWindowController?.Dispose();
        _settingsMenuController?.Dispose();
        _shedController?.Dispose();
        _inventoryController?.Dispose();
    }
    
    private UpgradeHandlersRepository CreateRepository()
    {
        UpgradeItemConfig[] upgradeConfigs = ContentDataSourceLoader.LoadUpgradeItemConfigs(_dataSourcePath);
        var repository = new UpgradeHandlersRepository(upgradeConfigs);
        AddRepository(repository);

        return repository;
    }
    
    private InventoryController CreateInventoryController(Transform placeForUi)
    {
        _inventoryController = new InventoryController(placeForUi, _profilePlayer.Inventory);
        AddController(_inventoryController);

        return _inventoryController;
    }
}
