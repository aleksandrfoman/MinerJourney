using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
namespace Content.Scripts
{
    public class MiningResource : MonoBehaviour
    {
        public EResourceType ResourceType => resourceType;
        public Color Color => color;
        [SerializeField] private Color color;
        [SerializeField] private EResourceType resourceType;
        [SerializeField] private QuickOutline quickOutline;
        [SerializeField,ReadOnly] private Vector2Int tilePos;
        private bool isOutline;
        public void Init(Vector2Int pos)
        {
            Vector3 newPos = new Vector3(pos.x, 0.5f, pos.y);
            transform.position = newPos;
            transform.localEulerAngles = new Vector3(0f, Random.value * 360f, 0f);
            Vector3Int ceilPos = Vector3Int.CeilToInt(newPos);
            tilePos = new Vector2Int(ceilPos.x,ceilPos.z);
            quickOutline.Init();
            isOutline = false;
            quickOutline.enabled = false;
        }

        public void TakeDamage()
        {
            transform.DOScale(Vector3.one * 0.8f, 0.125f).SetEase(Ease.InFlash).OnComplete((() =>
            {
                transform.DOScale(Vector3.one, 0.125f).SetEase(Ease.OutFlash);
            }));
        }
        
        public void EnableOutline(bool value)
        {
            if(value==isOutline) return;
            
            isOutline = value;
            quickOutline.enabled = value;
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
