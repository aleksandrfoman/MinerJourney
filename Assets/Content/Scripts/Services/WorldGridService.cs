using System.Collections.Generic;
using UnityEngine;

namespace Content.Scripts.Services
{
    public class WorldGridService : MonoBehaviour
    {
        private Dictionary<Vector2Int, ECellType> gridMap = new Dictionary<Vector2Int, ECellType>();
        public void AddCell(Vector2Int pos,ECellType cellType)
        {
            if (!HasCell(pos, out ECellType type))
            {
                gridMap.Add(pos,cellType);
            }
            else
            {
                gridMap[pos] = cellType;
            }
        }

        public void RemoveCell(Vector2Int pos)
        {
            if (HasCell(pos, out ECellType type))
            {
                gridMap.Remove(pos);
            }
        }

        public bool HasCell(Vector2Int pos, out ECellType cellType)
        {
            if (gridMap.ContainsKey(pos))
            {
                cellType = gridMap[pos];
                return true;
            }
            cellType = ECellType.None;
            return false;
        }
    }

    public enum ECellType
    {
        None,
        Empty,
        NotEmpty,
    }
}
