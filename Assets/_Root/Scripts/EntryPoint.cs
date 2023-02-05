using _Root.Scripts;
using _Root.Scripts.Tool.Ads.UnityAds;
using _Root.Scripts.Tool.Analytics;
using Profile;
using Tool;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    private readonly ResourcePath _entryPointConfigPath =
        new ResourcePath("Configs/EntryPoint/EntryPointConfiguration");

    [SerializeField] private Transform _placeForUi;
    [SerializeField] private AnalyticsManager _analyticsManager;
    [SerializeField] private UnityAdsService _adsService;

    private MainController _mainController;


    private void Start()
    {
        EntryPointConfiguration _configuration = ContentDataSourceLoader.LoadEntryPointConfigs(_entryPointConfigPath);
        var profilePlayer = new ProfilePlayer(_configuration.SpeedCar, _configuration.InitialState,_configuration.JumpHeight, 
            _configuration.VisibilityRange, _configuration.Endurance);
        
        _mainController = new MainController(_placeForUi, profilePlayer, _analyticsManager, _adsService);

        if (_adsService.isInitialized) OnAdsInitialized();
        else _adsService.Initialized.AddListener(OnAdsInitialized);
    }

    private void OnDestroy()
    {
        _adsService.Initialized.RemoveListener(OnAdsInitialized);
        _mainController.Dispose();
    }

    private void OnAdsInitialized() => _adsService.InterstitialPlayer.Play();
}
