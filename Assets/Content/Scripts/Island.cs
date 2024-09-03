using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Content.Scripts.SO;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Content.Scripts
{
    public class Island : MonoBehaviour
    {
        public List<Tile> IslandTilesList => islandTilesList;
        
        [SerializeField] private IslandSO islandSettings;
        [SerializeField,ReadOnly] private List<Tile> islandTilesList;

        [Button]
        private void FoundTiles()
        {
            IslandTilesList.Clear();
            Tile[] tiles = gameObject.GetComponentsInChildren<Tile>();
            islandTilesList = tiles.ToList();
        }
    }
}
