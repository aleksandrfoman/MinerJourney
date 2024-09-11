using System;
using DG.Tweening;
using UnityEngine;

namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerAnimator
    {
        [SerializeField] private Animator animator;
        private int _layerCount = 2;
        
        public void PlayRun()
        {
            animator.SetBool("IsRun",true);
        }
        
        public void PlayIdle()
        {
            animator.SetBool("IsRun",false);
        }

        public void PlayDead()
        {
            animator.SetBool("IsAim",false);
            animator.SetTrigger("TriggerDeath");
        }
        
        public void PlayAttack(bool value)
        {
            animator.SetBool("IsAttack",value);
        }
        
        

        private void EnableAimLayer(bool value)
        {
            float weight = value ? 1 : 0;
            DOTween.To(() => animator.GetLayerWeight(1), x => animator.SetLayerWeight(1, x), weight, 0.25f);
        }
        
        public void UpdateMovement(Vector2 dir)
        {
            if (dir.x != 0 || dir.y != 0)
            {
                PlayRun();   
            }
            else
            {
                PlayIdle();
            }
        }
    }
}