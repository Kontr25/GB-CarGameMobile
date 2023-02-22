using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace Tool.Bundles.Examples
{
    internal class AssetBundleViewBase : MonoBehaviour
    {
        private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1rQzWdcChHhJJBTe4rf1D0Kwi1a43jxWR";
        private const string UrlAssetBundleAudio = "https://drive.google.com/uc?export=download&id=1I7euU6Hv5yrn1ektprUumbGHEikklk3Y";
        private const string UrlAssetBundleButtonSprite = "https://drive.google.com/uc?export=download&id=1c7cJt0PzCqm5IO_txQp8GRCgbtXir-3Z";

        [SerializeField] private DataSpriteBundle[] _dataSpriteBundles;
        [SerializeField] private DataAudioBundle[] _dataAudioBundles;
        [SerializeField] private DataButtonSpriteBundle[] _dataButtonSpriteBundles;

        private AssetBundle _spritesAssetBundle;
        private AssetBundle _audioAssetBundle;
        private AssetBundle _buttonSpriteAssetBundle;


        protected IEnumerator DownloadAndSetAssetBundles()
        {
            yield return GetSpritesAssetBundle();
            yield return GetAudioAssetBundle();
            yield return GetButtonSpritesAssetBundle();

            if (_spritesAssetBundle != null)
                SetSpriteAssets(_spritesAssetBundle);
            else
                Debug.LogError($"AssetBundle {nameof(_spritesAssetBundle)} failed to load");

            if (_audioAssetBundle != null)
                SetAudioAssets(_audioAssetBundle);
            else
                Debug.LogError($"AssetBundle {nameof(_audioAssetBundle)} failed to load");

            if (_buttonSpriteAssetBundle != null)
                SetButtonSpriteAssets(_buttonSpriteAssetBundle);
            else
                Debug.LogError($"AssetBundle {nameof(_buttonSpriteAssetBundle)} failed to load");
        }

        private IEnumerator GetSpritesAssetBundle()
        {
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

            yield return request.SendWebRequest();

            while (!request.isDone)
                yield return null;

            StateRequest(request, out _spritesAssetBundle);
        }

        private IEnumerator GetAudioAssetBundle()
        {
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleAudio);

            yield return request.SendWebRequest();

            while (!request.isDone)
                yield return null;

            StateRequest(request, out _audioAssetBundle);
        }
        
        private IEnumerator GetButtonSpritesAssetBundle()
        {
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleButtonSprite);

            yield return request.SendWebRequest();

            while (!request.isDone)
                yield return null;

            StateRequest(request, out _buttonSpriteAssetBundle);
        }

        private void StateRequest(UnityWebRequest request, out AssetBundle assetBundle)
        {
            if (request.error == null)
            {
                assetBundle = DownloadHandlerAssetBundle.GetContent(request);
                Debug.Log("Complete");
            }
            else
            {
                assetBundle = null;
                Debug.LogError(request.error);
            }
        }

        private void SetSpriteAssets(AssetBundle assetBundle)
        {
            foreach (DataSpriteBundle data in _dataSpriteBundles)
                data.Image.sprite = assetBundle.LoadAsset<Sprite>(data.NameAssetBundle);
        }

        private void SetAudioAssets(AssetBundle assetBundle)
        {
            foreach (DataAudioBundle data in _dataAudioBundles)
            {
                data.AudioSource.clip = assetBundle.LoadAsset<AudioClip>(data.NameAssetBundle);
                data.AudioSource.Play();
            }
        }
        
        private void SetButtonSpriteAssets(AssetBundle assetBundle)
        {
            foreach (DataButtonSpriteBundle data in _dataButtonSpriteBundles)
                data.Button.image.sprite = assetBundle.LoadAsset<Sprite>(data.NameAssetBundle);
        }
    }
}
