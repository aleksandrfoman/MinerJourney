using System;
using System.Collections;
using System.Collections.Generic;
using Content.Scripts.SO;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Content.Scripts.Services
{
    public class WorldResourcesService : MonoBehaviour
    {
        [SerializeField] private WorldResourcesSO worldResourcesSO;
        [SerializeField] private Transform parentTransform;
        private WorldTileService worldTileService;
        private PlayerService playerService;
        
        [Inject]
        private void Construct(WorldTileService worldTileService, PlayerService playerService)
        {
            this.worldTileService = worldTileService;
            this.playerService = playerService;
            InitSpawnResources();
        }
        
        private void InitSpawnResources()
        {
            for (int i = 0; i < worldResourcesSO.TilesResources.Length; i++)
            {
                List<Vector2Int> tilePosList = 
                    worldTileService.GetTileTypeListPos(worldResourcesSO.TilesResources[i].TileType);
                MiningResource[] miningResourcesPrefabs = worldResourcesSO.TilesResources[i].ResourcesPrefab;
                
                if (tilePosList.Count > 0)
                {
                    for (int j = 0; j < tilePosList.Count; j++)
                    {
                        if (Random.value <= 0.7f)
                        {
                            if (worldTileService.TrySetTileEmpty(tilePosList[j]))
                            {
                                int rnd = Random.Range(0, miningResourcesPrefabs.Length);
                                MiningResource curResource = Instantiate(miningResourcesPrefabs[rnd]);
                                curResource.transform.parent = parentTransform;
                                curResource.Init(tilePosList[j]);
                            }
                        }
                    }
                }
            }
        }
    }
}
