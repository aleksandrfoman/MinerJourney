using UnityEngine;

namespace Content.Scripts.PlayerScripts.State
{
    public class PlayerActionMining : PlayerActionBase
    {
        private Camera _camera;

        public override void StartState()
        {
            base.StartState();
            if (_camera == null)
            {
                _camera = Camera.main;
            }
            
        }

        public override void ProcessState()
        {
            
        }
        
        public override void EndState()
        {
            base.EndState();
        }
    }
}
