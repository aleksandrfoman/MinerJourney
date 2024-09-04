using System.Collections.Generic;
using Content.Scripts.SO;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class WorldGeneratorService : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Island[] islands;
        private WorldTileService worldTileService;
        private WorldGridService worldGridService;
        [Inject]
        private void Construct(WorldTileService worldTileService, WorldGridService worldGridService)
        {
            this.worldTileService = worldTileService;
            this.worldGridService = worldGridService;
            
            InitIslands();
        }

        private void InitIslands()
        {
            for (int i = 0; i < islands.Length; i++)
            {
                for (var j = 0; j < islands[i].IslandTilesList.Count; j++)
                {
                    for (int k = 0; k < islands[i].IslandTilesList.Count; k++)
                    {
                        islands[i].IslandTilesList[k].Init();
                    }
                    worldTileService.AddTile(islands[i].IslandTilesList[j]);
                }
            }

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    Vector3 pos = new Vector3(i, 0, j) + spawnPoint.transform.position;
                    Vector3Int ceilPos = Vector3Int.CeilToInt(pos);
                    worldGridService.AddCell(new Vector2Int(ceilPos.x,ceilPos.z),ECellType.NotEmpty);
                }
            }
            
        }
    }
}
