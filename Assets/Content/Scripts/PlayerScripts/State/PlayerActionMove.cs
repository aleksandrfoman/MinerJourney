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
                        
            if (Machine.PlayerMining.HasFoundMiningResource())
            {
                if (Machine.PlayerMining.CheckDistance())
                {
                    Machine.PlayerMovement.Rotate(Machine.PlayerMining.MiningResource.transform.position);
                    Machine.PlayerAnimator.PlayAttack(true);
                    Machine.PlayerMining.MiningResource.EnableOutline(true);
                    
                    if (Machine.PlayerAnimator.IsAttackComplete)
                    {
                        Machine.PlayerAnimator.ResetCompleteAttack();
                        Machine.PlayerMining.MiningResource.TakeDamage();
                        Machine.PlayerMining.PlayParticle();
                    }
                }
                else
                {
                    Machine.PlayerAnimator.PlayAttack(false);
                    Machine.PlayerMining.DisableMining();
                }
            }
            
            Machine.PlayerMovement.MyInput();
            Machine.PlayerMovement.Rotate();
            Machine.PlayerMovement.Movement();
            Machine.PlayerFollow.UpdatePointMove();
            Machine.PlayerAnimator.UpdateMovement(Machine.PlayerMovement.Direction);
        }
        
        public override void EndState()
        {
            base.EndState();
        }
    }
}
