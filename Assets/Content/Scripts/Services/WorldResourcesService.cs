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
        
        private List<MiningResource> miningResourcesList = new List<MiningResource>();

        public MiningResource FindNearMiningResource(Vector3 pos, float findRadius)
        {
            if (miningResourcesList.Count < 0)
            {
                return null;
            }

            float tempDist = findRadius;
            MiningResource miningResource = null;

            if (miningResourcesList.Count > 0)
            {
                for (int i = 0; i < miningResourcesList.Count; i++)
                {
                    MiningResource curMiningResource = miningResourcesList[i];
                    if (curMiningResource != null)
                    {
                        float dist = Vector3.Distance(pos, curMiningResource.transform.position);
                        if (dist < tempDist)
                        {
                            tempDist = dist;
                            miningResource = curMiningResource;
                        }
                    }
                }
            }
            return miningResource;
        }


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
                                miningResourcesList.Add(curResource);
                            }
                        }
                    }
                }
            }
        }
    }
}
