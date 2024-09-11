using System;
using Content.Scripts.Services;
using UnityEngine;
using Zenject;
namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerMining
    {
        public MiningResource MiningResource => curMiningResource;
        [SerializeField] private float findRadius = 0.1f;
        private WorldResourcesService worldResourcesService;
        private Player player;
        private MiningResource curMiningResource;
        
        public void Init(WorldResourcesService worldResourcesService, Player player)
        {
            this.worldResourcesService = worldResourcesService;
            this.player = player;
        }

        private MiningResource FindNearMiningResource()
        {
            return worldResourcesService.FindNearMiningResource(player.transform.position, 4f);
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
            curMiningResource = null;
        }

        public bool CheckDistance()
        {
            return Vector3.Distance(curMiningResource.transform.position, player.transform.position) <= findRadius;
        }
        
        public bool HasFoundMiningResource()
        {
            MiningResource miningResource = FindNearMiningResource();
            if (miningResource)
            {
                if (curMiningResource != null)
                {
                    DisableMining();
                }
                curMiningResource = miningResource;
                return true;
            }
            return false;
        }
    }
}
