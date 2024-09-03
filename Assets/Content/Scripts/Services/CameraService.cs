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
        [SerializeField] private Transform followTarget;
        [SerializeField] private Transform playerFollow;

        [Inject]
        private void Construct()
        {
            SetVirtualCamera(ECameraState.Player,0f);
        }
        
        public void SetVirtualCamera(ECameraState eCameraState, float duration) =>
            cameraVirtualControl.SetVirtualCamera(eCameraState, duration);

        public void SetFollowCameraPos(Vector3 position)
        {
            position.y = 0f;
            followTarget.position = position;
        }
        
        public void SetFollowCameraPos(Vector3 position, float duration)
        {
            position.y = 0f;
            followTarget.DOMove(position,duration).SetUpdate(UpdateType.Fixed).SetEase(Ease.Linear);
        }
        
        [Serializable]
        public class CameraVirtualControl
        {
            [SerializeField] private CinemachineBrain cinemaBrain;
            [SerializeField] private CinemachineVirtualCamera playerCamera;
            [SerializeField] private CinemachineVirtualCamera followTargetCamera;
            
            private float _curFov;
            
            public void SetVirtualCamera(ECameraState eCameraState, float duration)
            {
                cinemaBrain.m_DefaultBlend.m_Time = duration;
                
                playerCamera.Priority = 10;
                followTargetCamera.Priority = 10;
                
                switch (eCameraState)
                {
                    case ECameraState.Player:
                        playerCamera.Priority = 12;
                        break;
                    case ECameraState.FollowTarget:
                        followTargetCamera.Priority = 12;
                        break;
                }
            }
        }
        
        public enum ECameraState
        {
            Player,
            FollowTarget
        }
    }
}
