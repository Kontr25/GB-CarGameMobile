using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tool.Bundles.Examples
{
    [Serializable]
    
    internal class DataButtonSpriteBundle
    {
        [field: SerializeField] public string NameAssetBundle { get; private set; }
        [field: SerializeField] public Button Button { get; private set; }
    }
}