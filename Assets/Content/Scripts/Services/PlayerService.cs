using Content.Scripts.PlayerScripts;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class PlayerService : MonoBehaviour
    {
        public Player CurPlayer => curPlayer;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Player playerPrefab;
        private Player curPlayer;
        private WorldResourcesService worldResourcesService;
        private CameraService cameraService;
        
        [Inject]
        private void Construct(CameraService cameraService, WorldResourcesService worldResourcesService)
        {
            this.worldResourcesService = worldResourcesService;
            this.cameraService = cameraService;
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Player player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
            curPlayer = player;
            player.Init(cameraService.PlayerFollow,worldResourcesService);
        }
    }
}
