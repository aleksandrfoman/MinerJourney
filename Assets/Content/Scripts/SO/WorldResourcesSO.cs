using System;
using UnityEngine;

namespace Content.Scripts.SO
{
    [CreateAssetMenu(fileName = "WorldResourcesSO", menuName = "GameData/WorldResourcesSO", order = 0)]
    public class WorldResourcesSO : ScriptableObject
    {
        [field: SerializeField] public TileResource[] TilesResources { get; private set; }
    }

    [Serializable]
    public class TileResource
    {
        [field: SerializeField] public ETileType TileType { get; private set; }
        [field: SerializeField] public MiningResource[] resourcesPrefab { get; private set; }
    }
}