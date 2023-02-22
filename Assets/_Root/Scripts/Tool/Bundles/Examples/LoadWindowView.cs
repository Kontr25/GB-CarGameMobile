using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;

namespace Tool.Bundles.Examples
{
    internal class LoadWindowView : AssetBundleViewBase
    {
        [Header("Asset Bundles")]
        [SerializeField] private Button _loadAssetsButton;

        [Header("Addressables")]
        [SerializeField] private AssetReference _spawningButtonPrefab;
        [SerializeField] private AssetReference _backgroundSprite;
        [SerializeField] private RectTransform _spawnedButtonsContainer;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Button _spawnAssetButton;
        [SerializeField] private Button _addBackgroundButton;
        [SerializeField] private Button _removeBackgroundButton;

       private readonly List<AsyncOperationHandle<GameObject>> _addressablePrefabs =
            new List<AsyncOperationHandle<GameObject>>();

       private AsyncOperationHandle<Sprite> _addressableSprites;


        private void Start()
        {
            _loadAssetsButton.onClick.AddListener(LoadAssets);
            _spawnAssetButton.onClick.AddListener(SpawnPrefab);
            _addBackgroundButton.onClick.AddListener(AddBackground);
            _removeBackgroundButton.onClick.AddListener(RemoveBackground);
        }

        private void OnDestroy()
        {
            _loadAssetsButton.onClick.RemoveAllListeners();
            _spawnAssetButton.onClick.RemoveAllListeners();
            _addBackgroundButton.onClick.RemoveAllListeners();
            _removeBackgroundButton.onClick.RemoveAllListeners();

            DespawnPrefabs();
        }


        private void LoadAssets()
        {
            _loadAssetsButton.interactable = false;
            StartCoroutine(DownloadAndSetAssetBundles());
        }

        private void SpawnPrefab()
        {
           AsyncOperationHandle<GameObject> addressablePrefab =
               Addressables.InstantiateAsync(_spawningButtonPrefab, _spawnedButtonsContainer);

            _addressablePrefabs.Add(addressablePrefab);
        }

        private void DespawnPrefabs()
        {
            foreach (AsyncOperationHandle<GameObject> addressablePrefab in _addressablePrefabs)
                Addressables.ReleaseInstance(addressablePrefab);

            _addressablePrefabs.Clear();
        }

        private void AddBackground()
        {
            if(_addressableSprites.IsValid()) return;
            
            _addressableSprites = Addressables.LoadAssetAsync<Sprite>(_backgroundSprite);
            _addressableSprites.Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    _backgroundImage.sprite = handle.Result;
                }
                else
                {
                    Debug.LogWarning("Failed to load background sprite: " + handle.OperationException.Message);
                }
            };
        }

        private void RemoveBackground()
        {
            if (_addressableSprites.IsValid())
            {
                _addressableSprites.Completed += handle =>
                {
                    Addressables.Release(handle);
                };
                _backgroundImage.sprite = null;
            }
        }
    }
}
