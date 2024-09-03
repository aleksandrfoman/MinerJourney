using Sirenix.OdinInspector;
using UnityEngine;
namespace Content.Scripts
{
    public class IslandGenerator : MonoBehaviour
    {
        [SerializeField] private Vector2Int size;
        [SerializeField] private Vector2Int offset;
        [SerializeField] private Tile tilePrefab;

        [Button]
        public void Generate()
        {
            GameObject parent = new GameObject("Island");
            
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Vector3 pos = new Vector3(x, 0f, y);
                    Tile tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                    tile.transform.parent = parent.transform;
                }
            }
        }
    }
}
