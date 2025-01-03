using System;
using Content.Scripts.Fabric;
using Content.Scripts.Services;
using Content.Scripts.SO;
using Content.Scripts.UI;
using DG.Tweening;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Content.Scripts
{
    public class MiningResource : MonoBehaviour
    {
        public Color Color => miningResourceSO.Color;
        public Vector2Int TilePos => tilePos;

        [SerializeField] private MiningResourceSO miningResourceSO;
        [SerializeField] private QuickOutline quickOutline;
        [SerializeField] private Transform mesh;
        [SerializeField] private ResourcesBar resourcesBar;
        [SerializeField,ReadOnly] private Vector2Int tilePos;
        private WorldResourcesService worldResourcesService;
        private bool isSelect;
        private float curHealth;
        public void Init(Vector2Int pos, WorldResourcesService worldResourcesService)
        {
            this.worldResourcesService = worldResourcesService;
            Vector3 newPos = new Vector3(pos.x, 0.5f, pos.y);
            transform.position = newPos;
            mesh.localEulerAngles = new Vector3(0f, Random.value * 360f, 0f);
            Vector3Int ceilPos = Vector3Int.CeilToInt(newPos);
            tilePos = new Vector2Int(ceilPos.x,ceilPos.z);
            quickOutline.Init();
            isSelect = false;
            quickOutline.enabled = false;
            curHealth = miningResourceSO.Health;
        }

        public void TakeDamage(float damage, Action OnDead = null)
        {
            ScaleAnim();
            curHealth -= damage;
            resourcesBar.BarFill(curHealth/miningResourceSO.Health);
            if (curHealth <= 0)
            {
                OnDead?.Invoke();
                SpawnDrop();
                Dead();
            }
        }

        public void SpawnDrop()
        {
            if(miningResourceSO.DropList.Count<0) return;
            
            for (int i = 0; i < miningResourceSO.DropList.Count; i++)
            {
                for (int j = 0; j < miningResourceSO.DropList[i].Count; j++)
                {
                    
                    DropItem dropItem = PrefabSpawnerFabric.Instance.SpawnItem(miningResourceSO.DropList[i].DropItem);
                    dropItem.Init(transform.position);
                }
            }
        }

        private void Dead()
        {
            worldResourcesService.RemoveResource(this);
            Destroy(gameObject);
        }

        private void ScaleAnim()
        {
            mesh.DOScale(Vector3.one * 0.8f, 0.125f).SetEase(Ease.InFlash).OnComplete((() =>
            {
                mesh.DOScale(Vector3.one, 0.125f).SetEase(Ease.OutFlash);
            }));
        }
        
        private void EnableOutline(bool value)
        {
            quickOutline.enabled = value;
        }

        private void EnableBar(bool value)
        {
            resourcesBar.EnableBar(value);
        }

        public void EnableSelect(bool value)
        {
            if(value==isSelect) return;
            
            isSelect = value;
            EnableBar(value);
            EnableOutline(value);
        }
    }

    public enum EResourceType
    {
        Bush,
        Stone,
        IronOre,
        Tree
    }
}
