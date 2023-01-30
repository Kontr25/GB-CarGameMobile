using UnityEngine;

namespace Game.Unsorted
{
    public class DontDestroyedObject : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}