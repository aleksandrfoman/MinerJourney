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
        private Vector2 _animDir;
        
        public void PlayAim()
        {
            animator.SetBool("IsAim",true);
            animator.SetTrigger("TriggerAim");
            EnableAimLayer(true);
        }
        public void PlayRun()
        {
            animator.SetBool("IsAim",false);
            animator.SetTrigger("TriggerRun");
            EnableAimLayer(false);
        }

        public void PlayDead()
        {
            animator.SetBool("IsAim",false);
            animator.SetTrigger("TriggerDeath");
            EnableAimLayer(false);
        }
        
        public void PlayShoot()
        {
            animator.SetTrigger("TriggerShoot");
        }

        private void EnableAimLayer(bool value)
        {
            float weight = value ? 1 : 0;
            DOTween.To(() => animator.GetLayerWeight(1), x => animator.SetLayerWeight(1, x), weight, 0.25f);
        }
        
        public void UpdateDirectional(Vector2 dir)
        {
            _animDir = Vector2.Lerp(_animDir, dir, Time.deltaTime*10f);
            
            animator.SetFloat("Horizontal", _animDir.x);
            animator.SetFloat("Vertical",_animDir.y);
        }
    }
}