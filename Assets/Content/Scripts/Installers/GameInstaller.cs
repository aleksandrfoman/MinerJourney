using Content.Scripts.Fabric;
using Content.Scripts.Misc;
using Content.Scripts.Services;
using Zenject;
namespace Content.Scripts.Installers
{
    public class GameInstaller : MonoBinder
    {
        public override void InstallBindings()
        {
            Container.Bind<PrefabSpawnerFabric>().AsSingle().NonLazy();
            
            BindService<WorldGridService>();
            BindService<WorldTileService>();
            BindService<WorldGeneratorService>();
            BindService<WorldResourcesService>();
            BindService<CameraService>();
            BindService<PlayerService>();
            BindService<GameCanvasService>();
        }
    }
}