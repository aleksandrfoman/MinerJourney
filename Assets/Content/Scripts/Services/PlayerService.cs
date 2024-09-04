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
        
        [Inject]
        private void Construct(CameraService cameraService)
        {
            SpawnPlayer(cameraService.PlayerFollow);
        }

        private void SpawnPlayer(Transform playerFollow)
        {
            Player player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
            curPlayer = player;
            player.Init(playerFollow);
        }
    }
}
