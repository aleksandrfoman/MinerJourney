using System;
using System.Collections;
using System.Collections.Generic;
using Content.Scripts.SO;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class WorldResourcesService : MonoBehaviour
    {
        [SerializeField] private WorldResourcesSO worldResourcesSO;
        
        private WorldTileService worldTileService;
        private WorldGridService worldGridService;
     
        [Inject]
        private void Construct(WorldTileService worldTileService, WorldGridService worldGridService)
        {
            this.worldTileService = worldTileService;
            this.worldGridService = worldGridService;
        }

        private void Update()
        {
            ResourcesSpawnerUpdate();
        }
        
        private void ResourcesSpawnerUpdate()
        {
            
        }
    }
}