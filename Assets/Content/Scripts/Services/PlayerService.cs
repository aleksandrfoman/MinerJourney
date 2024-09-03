using Content.Scripts.PlayerScripts;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Player playerPrefab;
        
        [Inject]
        private void Construct(CameraService cameraService)
        {
            SpawnPlayer(cameraService.PlayerFollow);
        }

        private void SpawnPlayer(Transform playerFollow)
        {
            Player player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
            player.Init(playerFollow);
        }
    }
}
