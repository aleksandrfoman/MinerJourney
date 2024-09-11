using System;
using Content.Scripts.PlayerScripts.State;
using Content.Scripts.Services;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Content.Scripts.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        public PlayerMovement PlayerMovement => playerMovement;
        public PlayerMining PlayerMining => playerMining;
        public PlayerAnimator PlayerAnimator => playerAnimator;
        public PlayerFollow PlayerFollow => playerFollow;
        
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerAnimator playerAnimator;
        [SerializeField] private PlayerMining playerMining;
        [SerializeField] private PlayerStateMachine stateMachine;
        [SerializeField] private PlayerFollow playerFollow;
        
        public void Init(Transform followPoint,WorldResourcesService worldResourcesService)
        {
            playerFollow.Init(transform,followPoint);
            playerMining.Init(worldResourcesService,this);
            stateMachine.Init(this);
        }

        private void OnDestroy()
        {
            playerFollow.Destroy();
        }
    }
}