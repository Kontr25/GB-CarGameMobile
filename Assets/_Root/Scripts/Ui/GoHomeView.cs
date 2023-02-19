using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Root.Scripts.Ui
{
    public class GoHomeView : MonoBehaviour
    {
        [SerializeField] private Button _goHomeButton;

        public void Init(UnityAction goHome) =>
            _goHomeButton.onClick.AddListener(goHome);

        private void OnDestroy() =>
            _goHomeButton.onClick.RemoveAllListeners();
    }
}