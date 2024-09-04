using Sirenix.OdinInspector;
using UnityEngine;
namespace Content.Scripts
{
    public class MiningResource : MonoBehaviour
    {
        public EResourceType ResourceType => resourceType;
        [SerializeField] private EResourceType resourceType;
        
        [SerializeField,ReadOnly] private Vector2Int tilePos;

        public void Init(Vector2Int pos)
        {
            Vector3 newPos = new Vector3(pos.x, 0.5f, pos.y);
            transform.position = newPos;
            transform.localEulerAngles = new Vector3(0f, Random.value * 360f, 0f);
            Vector3Int ceilPos = Vector3Int.CeilToInt(newPos);
            tilePos = new Vector2Int(ceilPos.x,ceilPos.z);
        }
    }

    public enum EResourceType
    {
        Bush,
        Stone,
        Tree
    }
}
