using UnityEngine;

namespace Content.Scripts.PlayerScripts.State
{
    public class PlayerActionMove : PlayerActionBase
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
            Machine.PlayerMovement.MyInput();
            Machine.PlayerMovement.Rotate();
            Machine.PlayerMovement.Movement();
            Machine.PlayerFollow.UpdatePointMove();

            if (Machine.PlayerMining.HasFoundMiningResource())
            {
                Machine.PlayerMining.Mining();
                Machine.PlayerAnimator.PlayAttack(true);
            }
            else
            {
                Machine.PlayerAnimator.PlayAttack(false);
                Machine.PlayerAnimator.UpdateMovement(Machine.PlayerMovement.Direction);
            }
        }
        
        

        public override void EndState()
        {
            base.EndState();
        }
    }
}
