using Content.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Content.Scripts
{
    public class BootLoader : MonoBehaviour
    {
        [Inject]
        private void Construct(SceneService sceneService)
        {
            sceneService.LoadScene("Game");
        }
    }
}
