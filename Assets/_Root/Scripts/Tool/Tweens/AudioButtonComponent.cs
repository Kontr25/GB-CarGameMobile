using _Root.Scripts.Tool.Sounds;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Scripts.Tool.Tweens
{
    [RequireComponent(typeof(Button))]
    public class AudioButtonComponent : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Button _button;
        [SerializeField] private ClickType clickType;


        private void OnValidate() => InitComponents();
        private void Awake() => InitComponents();

        private void Start() => _button.onClick.AddListener(OnButtonClick);
        private void OnDestroy() => _button.onClick.RemoveAllListeners();

        private void InitComponents()
        {
            _button ??= GetComponent<Button>();
        }


        private void OnButtonClick() => ActivateSound();
        private void ActivateSound() => SoundManager.Click(clickType);
    }
}