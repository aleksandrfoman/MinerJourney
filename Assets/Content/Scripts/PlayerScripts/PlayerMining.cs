using System;
using Content.Scripts.Services;
using UnityEngine;
using Zenject;
namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerMining
    {
        [SerializeField] private float findRadius = 1.5f;
        private WorldResourcesService worldResourcesService;
        private Player player;
        private MiningResource curMiningResource;
        
        [Inject]
        private void Construct(WorldResourcesService worldResourcesService, PlayerService playerService)
        {
            player = playerService.CurPlayer;
            this.worldResourcesService = worldResourcesService;
        }

        private MiningResource FindNearMiningResource()
        {
            Debug.Log(worldResourcesService);
            return worldResourcesService.FindNearMiningResource(player.transform.position, findRadius);
        }


        public void Mining()
        {
            if (curMiningResource != null)
            {
                curMiningResource.EnableOutline(true);
                Debug.Log("Mining" + curMiningResource);
            }
        }

        public void DisableMining()
        {
            curMiningResource.EnableOutline(false);
        }
        
        public bool HasFoundMiningResource()
        {
            MiningResource miningResource = FindNearMiningResource();
                
            if (miningResource)
            {
                curMiningResource = miningResource;
                return true;
            }
            return false;
        }
    }
}
