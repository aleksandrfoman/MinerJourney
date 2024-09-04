using System.Collections.Generic;
using Content.Scripts.SO;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class WorldTileService : MonoBehaviour
    {
        [SerializeField] private TileSO tileSO;
        private WorldGridService worldGridService;
        private Dictionary<Vector2Int, Tile> tileMap = new Dictionary<Vector2Int, Tile>();
        private Dictionary<ETileType, List<Vector2Int>> tileTypesMap = new Dictionary<ETileType, List<Vector2Int>>();
        
        [Inject]
        private void Construct(WorldGridService worldGridService)
        {
            this.worldGridService = worldGridService;
        }
        
        public void AddTile(Tile tile)
        {
            if (HasTile(tile)) return;
            
            AddElementTileType(tile.TileType);
            tileTypesMap[tile.TileType].Add(tile.TilePos);
            
            tileMap.Add(tile.TilePos,tile);
            worldGridService.AddCell(tile.TilePos,ECellType.Empty);
        }

        public void RemoveTile(Vector2Int pos)
        {
            tileTypesMap[tileMap[pos].TileType].Remove(pos);
            tileMap.Remove(pos);
            worldGridService.AddCell(pos,ECellType.None);
        }
        
        public void RemoveTile(Tile tile)
        {
            RemoveTile(tile.TilePos);
        }
        
        public bool HasTile(Tile tile)
        {
            return tileMap.ContainsKey(tile.TilePos);
        }
        
        public List<Vector2Int> GetTileTypeListPos(ETileType tileType)
        {
            AddElementTileType(tileType);
            return tileTypesMap[tileType];
        }
        private void AddElementTileType(ETileType tileType)
        {
            if (!tileTypesMap.ContainsKey(tileType))
            {
                tileTypesMap.Add(tileType,new List<Vector2Int>());
            }
        }

        public bool TrySetTileEmpty(Vector2Int pos)
        {
            worldGridService.HasCell(pos, out ECellType cellType);
            if (cellType == ECellType.Empty)
            {
                worldGridService.AddCell(pos,ECellType.NotEmpty);
                return true;
            }
            return false;
        }
    }
}
