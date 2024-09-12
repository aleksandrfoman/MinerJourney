using System;
using System.Collections.Generic;
using UnityEngine;
namespace Content.Scripts.SO
{
    [CreateAssetMenu(fileName = "ResourceSO", menuName = "GameData/ResourceSO", order = 0)]
    public class MiningResourceSO : ScriptableObject
    {
        [field: SerializeField] public Color Color;
        [field: SerializeField] public float Health;
        [field: SerializeField] public List<MiningDropSettings> DropList { get; private set; }
    }
    
    [Serializable]
    public class MiningDropSettings
    {
        [field: SerializeField] public DropItem DropItem;
        [field: SerializeField] public int Count;
    }
}
