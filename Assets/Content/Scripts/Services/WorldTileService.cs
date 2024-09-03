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
        
        [Inject]
        private void Construct(WorldGridService worldGridService)
        {
            this.worldGridService = worldGridService;
        }
        
        public void AddTile(Tile tile)
        {
            if (HasTile(tile)) return;
            
            tileMap.Add(tile.TilePos,tile);
            worldGridService.AddCell(tile.TilePos,ECellType.Empty);
        }

        public void RemoveTile(Vector2Int pos)
        {
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

    }
}
