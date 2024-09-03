using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
namespace Content.Scripts.SO
{
    [CreateAssetMenu(fileName = "TileSO", menuName = "GameData/TileSO", order = 0)]
    public class TileSO : ScriptableObject
    {
        [SerializeField, TableList] private List<TileData> tileDatas;

        public Tile GetTile(ETileType tileType)
        {
            TileData tileData = tileDatas.Find(x => x.TileType == tileType);
            return tileData != null ? tileData.TilePrefab : null;
        }
    }

    [Serializable]
    public class TileData
    {
        [field: SerializeField,TableColumnWidth(2)] public ETileType TileType { get; private set; }
        [field: SerializeField] public Tile TilePrefab { get; private set; }
    }
}
