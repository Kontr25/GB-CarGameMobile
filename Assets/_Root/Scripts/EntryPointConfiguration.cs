using Profile;
using UnityEngine;

namespace _Root.Scripts
{
    [CreateAssetMenu (fileName = nameof(EntryPointConfiguration), menuName = "Configs/" + nameof(EntryPointConfiguration))]
    internal class EntryPointConfiguration : ScriptableObject
    {
        [SerializeField] private float _speedCar;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _visibilityRange;
        [SerializeField] private float _endurance;
        [SerializeField] private GameState _initialState;

        public float SpeedCar => _speedCar;

        public float JumpHeight => _jumpHeight;

        public float VisibilityRange => _visibilityRange;

        public float Endurance => _endurance;

        public GameState InitialState => _initialState;
    }
}