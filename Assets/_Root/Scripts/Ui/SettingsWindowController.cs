using Profile;
using Tool;
using UnityEngine;

namespace Ui
{
    internal class SettingsWindowController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/SettingsWindow");
        private readonly ProfilePlayer _profilePlayer;
        private readonly SettingsWindowView _view;


        public SettingsWindowController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(CloseWindow);
        }


        private SettingsWindowView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<SettingsWindowView>();
        }

        
        private void CloseWindow() =>
            _profilePlayer.CurrentState.Value = GameState.Start;
    }
}