using System;
using UnityEngine;

namespace _Root.Scripts.Tool.Sounds
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _forwardClickSound;
        [SerializeField] private AudioSource _backwardClickSound;
        [SerializeField] private AudioSource _startFightClickSound;
        [SerializeField] private AudioSource _fightClickSound;
        [SerializeField] private AudioSource _rewardClickSound;

        public static Action<ClickType> Click;

        private void OnEnable()
        {
            Click += ClickSound;
        }

        private void OnDisable()
        {
            Click -= ClickSound;
        }

        private void ClickSound(ClickType type)
        {
            switch (type)
            {
                case ClickType.Forward:
                    _forwardClickSound.Play();
                    break;
                case ClickType.Backward:
                    _backwardClickSound.Play();
                    break;
                case ClickType.StartFight:
                    _startFightClickSound.Play();
                    break;
                case ClickType.Fight:
                    _fightClickSound.Play();
                    break;
                case ClickType.Reward:
                    _rewardClickSound.Play();
                    break;
            }
        }
    }
}