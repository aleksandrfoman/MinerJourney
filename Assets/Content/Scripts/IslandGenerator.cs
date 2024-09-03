using Sirenix.OdinInspector;
using UnityEngine;
namespace Content.Scripts
{
    public class IslandGenerator : MonoBehaviour
    {
        [SerializeField] private Transform worldParent;
        [SerializeField] private Vector2Int size;
        [SerializeField] private Vector2Int offset;
        [SerializeField] private Tile tilePrefab;
     
        [Button]
        public void Generate()
        {
            GameObject parent = new GameObject("Island");
            GameObject collider = new GameObject("Collider");
            collider.transform.parent = parent.transform;
            collider.transform.position = 
                (new Vector3((size.x) / 2f, 0f, size.y / 2f)) + new Vector3(offset.x,0f,offset.y)+(-new Vector3(1f,0f,1f)*0.5f);
            collider.AddComponent<BoxCollider>().size = new Vector3(size.x, 1, size.y);
            
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Vector3 pos = new Vector3(x, 0f, y);
                    Tile tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                    tile.transform.parent = parent.transform;
                }
            }
            if(worldParent!=null)
                parent.transform.parent = worldParent;
        }
    }
}
