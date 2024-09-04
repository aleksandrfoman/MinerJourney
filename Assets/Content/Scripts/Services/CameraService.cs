using System;
using Cinemachine;
using Content.Scripts.PlayerScripts;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class CameraService : MonoBehaviour
    {
        public Transform PlayerFollow => playerFollow;
        
        [SerializeField] private CameraVirtualControl cameraVirtualControl;
        [SerializeField] private Transform playerFollow;

        [Inject]
        private void Construct()
        {
            SetVirtualCamera(ECameraState.Player,0f);
        }
        
        public void SetVirtualCamera(ECameraState eCameraState, float duration) =>
            cameraVirtualControl.SetVirtualCamera(eCameraState, duration);
        
        [Serializable]
        public class CameraVirtualControl
        {
            [SerializeField] private CinemachineBrain cinemaBrain;
            [SerializeField] private CinemachineVirtualCamera playerCamera;
            
            private float _curFov;
            
            public void SetVirtualCamera(ECameraState eCameraState, float duration)
            {
                cinemaBrain.m_DefaultBlend.m_Time = duration;
                
                playerCamera.Priority = 10;
                
                switch (eCameraState)
                {
                    case ECameraState.Player:
                        playerCamera.Priority = 12;
                        break;
                }
            }
        }
        
        public enum ECameraState
        {
            Player
        }
    }
}
