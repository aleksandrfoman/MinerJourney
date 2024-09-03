using Sirenix.OdinInspector;
using UnityEngine;
namespace Content.Scripts
{
    public class Tile : MonoBehaviour
    {
        public ETileType TileType => tileType;
        public Vector2Int TilePos => tilePos;
        
        [SerializeField] private ETileType tileType;
        [SerializeField,ReadOnly] private Vector2Int tilePos;

        public void Init()
        {
            Vector3Int ceilPos = Vector3Int.CeilToInt(transform.position);
            this.tilePos = new Vector2Int(ceilPos.x,ceilPos.z);
        }
    }

    public enum ETileType
    {
        Grass,
        Snow
    }
}
