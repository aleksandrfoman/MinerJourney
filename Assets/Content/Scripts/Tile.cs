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

        public void Init(Vector2Int tilePos)
        {
            this.tilePos = tilePos;
        }
    }

    public enum ETileType
    {
        Grass,
        Snow
    }
}
