using _Root.Scripts.Tool.Ads.UnityAds;
using _Root.Scripts.Tool.Analytics;
using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    [SerializeField] private const float _speedCar = 15f;
    [SerializeField] private const float _jumpHeight = 5f;
    [SerializeField] private const float _visibilityRange = 20f;
    [SerializeField] private const float _endurance = 10;
    private const GameState InitialState = GameState.Start;

    [SerializeField] private Transform _placeForUi;
    [SerializeField] private AnalyticsManager _analyticsManager;
    [SerializeField] private UnityAdsService _adsService;

    private MainController _mainController;


    private void Start()
    {
        var profilePlayer = new ProfilePlayer(_speedCar, InitialState,_jumpHeight, _visibilityRange, _endurance);
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
