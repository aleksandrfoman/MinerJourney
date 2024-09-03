using Content.Scripts.Misc;
using Content.Scripts.Services;
using UnityEngine;
using Zenject;
namespace Content.Scripts.Installers
{
    public class ProjectInstaller : MonoBinder
    {
        public override void InstallBindings()
        {
            BindService<SceneService>();
        }
    }
}