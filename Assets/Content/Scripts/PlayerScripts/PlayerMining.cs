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
        [SerializeField] private ParticleSystem miningParticle;
        private WorldResourcesService worldResourcesService;
        private Player player;
        private Material particleMaterial;
        private MiningResource curMiningResource;
        
        public void Init(WorldResourcesService worldResourcesService, Player player)
        {
            this.worldResourcesService = worldResourcesService;
            this.player = player;
            particleMaterial = miningParticle.GetComponent<ParticleSystemRenderer>().material;
        }

        private MiningResource FindNearMiningResource()
        {
            return worldResourcesService.FindNearMiningResource(player.transform.position, 4f);
        }

        public void PlayParticle()
        {
            miningParticle.gameObject.SetActive(true);
            particleMaterial.color = curMiningResource.Color;
            miningParticle.Play();
        }

        public void DisableMining()
        {
            curMiningResource.EnableSelect(false);
            curMiningResource = null;
        }

        public bool CheckDistance()
        {
            if (curMiningResource == null) return false;
            
            return Vector3.Distance(curMiningResource.transform.position, player.transform.position) <= findRadius;
        }
        
        public bool HasFoundMiningResource()
        {
            MiningResource miningResource = FindNearMiningResource();
            if (miningResource)
            {
                if (curMiningResource != null && curMiningResource!=miningResource)
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
