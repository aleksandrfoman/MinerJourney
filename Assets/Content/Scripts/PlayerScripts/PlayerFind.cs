using System;
using Content.Scripts.Services;
using Zenject;

namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerFind 
    {
        [Inject]
        private void Construct(WorldResourcesService worldResourcesService)
        {

        }
    }
}
