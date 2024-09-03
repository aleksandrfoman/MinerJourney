using UnityEngine;
namespace Content.Scripts.SO
{
    public class TileResourcesSO : MonoBehaviour
    {
        [field: SerializeField] public ETileType TileType { get; private set; }
        [field: SerializeField] public MiningResource[] resourcesPrefab { get; private set; }
    }
}
