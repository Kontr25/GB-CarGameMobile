using _Root.Scripts.Units;
using Profile;
using Tool;
using UnityEngine;

namespace _Root.Scripts.Ui
{
    internal class GoHomeController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/GoHomeView");

        private readonly GoHomeView _view;
        private readonly ProfilePlayer _profilePlayer;


        public GoHomeController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(GoHome);
        }


        private GoHomeView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<GoHomeView>();
        }

        private void GoHome() =>
            _profilePlayer.CurrentState.Value = GameState.Start;
    }
}