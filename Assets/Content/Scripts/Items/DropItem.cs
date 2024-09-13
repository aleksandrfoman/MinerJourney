using System;
using System.Collections;
using System.Collections.Generic;
using Content.Scripts.PlayerScripts;
using Content.Scripts.Services;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class DropItem : MonoBehaviour
{
    [SerializeField] private Transform meshTransform;
    [SerializeField] private TrailRenderer trailRenderer;
    
    private GameCanvasService gameCanvasService;
    private Camera cameraMain;
    
    [Inject]
    private void Construct(GameCanvasService gameCanvasService)
    {
        cameraMain = Camera.main;
        this.gameCanvasService = gameCanvasService;
    }
    public void Init(Vector3 spawnPos)
    {
        transform.position = spawnPos;
        transform.parent = null;
        transform.localScale = Vector3.one;
        trailRenderer.gameObject.SetActive(false);
        Vector3 randomDirection = Random.insideUnitSphere.normalized * 0.35f;
        randomDirection.y = 0.15f;
        Vector3 endPosition = transform.position + randomDirection;
        gameObject.SetActive(true);
        transform.DOJump(endPosition, 1f,1, 0.45f).
            SetEase(Ease.InQuad).OnComplete((StartAnimation));
    }
    
    public void Disable()
    {
        StopAnimation();
        Vector3 canvasPos = new Vector3(gameCanvasService.Backpack.position.x, gameCanvasService.Backpack.position.y, 4f);
        Vector3 pos = cameraMain.ScreenToWorldPoint(canvasPos);
        pos -= new Vector3(0.25f, 0.25f, 0f);
        pos = cameraMain.transform.InverseTransformPoint(pos);
        transform.parent = cameraMain.transform;
        trailRenderer.Clear();
        trailRenderer.gameObject.SetActive(true);
        transform.DOLocalJump(pos,0.5f,1,1f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
    
    #region Collision

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            Disable();
        }
    }
    #endregion
    
    #region Animation

    private Tween move;
    private Tween rotate;
        
    private void StartAnimation()
    {
        move?.Kill();
        rotate?.Kill();
            
        meshTransform.localEulerAngles = Vector3.zero;
        meshTransform.localPosition = Vector3.zero;
            
        rotate = meshTransform.DOLocalRotate(new Vector3(0f, 360f, 0f), 4f, RotateMode.LocalAxisAdd)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
        move = meshTransform.DOLocalMoveY(0.1f, 2f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void StopAnimation()
    {
        move?.Kill();
        rotate?.Kill();
    }

    #endregion
}
