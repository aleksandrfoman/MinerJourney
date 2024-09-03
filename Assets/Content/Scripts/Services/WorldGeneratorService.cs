using System.Collections.Generic;
using Content.Scripts.SO;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class WorldGeneratorService : MonoBehaviour
    {
        [SerializeField] private Island[] islands;
        private WorldTileService worldTileService;
        
        [Inject]
        private void Construct(WorldTileService worldTileService)
        {
            this.worldTileService = worldTileService;
            
            InitIslands();
        }

        private void InitIslands()
        {
            for (int i = 0; i < islands.Length; i++)
            {
                for (var j = 0; j < islands[i].IslandTilesList.Count; j++)
                {
                    worldTileService.AddTile(islands[i].IslandTilesList[j]);
                }
            }
        }
    }
}
