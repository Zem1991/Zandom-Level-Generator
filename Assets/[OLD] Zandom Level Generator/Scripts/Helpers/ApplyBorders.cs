using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Enums;

namespace ZandomLevelGenerator.Helpers
{
    public class ApplyBorders
    {
        public ApplyBorders(LevelGenerator levelGenerator)
        {
            LevelGenerator = levelGenerator;
        }

        private LevelGenerator LevelGenerator { get; }

        public void Apply(Room room)
        {
            Borders(room);
            Corners(room);
        }

        private void Borders(Room room)
        {
            Vector2Int start = room.Start - Vector2Int.one;
            Vector2Int size = room.Size + (Vector2Int.one * 2);
            bool borderTile(int col, int row)
            {
                Vector2Int coordinates = new(col, row);
                bool alreadyHaveTile = LevelGenerator.Level.TileMap.Has(coordinates);
                Tile tile = LevelGenerator.Level.TileMap.Get(coordinates);
                if (tile == null)
                {
                    tile = LevelGenerator.Level.TileMap.Create(coordinates);
                    room.Tiles.Add(tile);
                }
                //else if (tile.Type != TileType.ROOM_BORDER)
                //{
                //    throw new System.Exception($"Border tile at {coordinates} would be invalid.");
                //}
                tile.MentionedRooms.Add(room);
                TryChange(tile, TileType.ROOM_BORDER);
                return true;
            }
            TileMapIterator iterator = new();
            iterator.IterateBorder(start, size, borderTile);
        }

        private void Corners(Room room)
        {
            Vector2Int start = room.Start - Vector2Int.one;
            Vector2Int size = room.Size + (Vector2Int.one * 2);
            Vector2Int bl = start;
            Vector2Int br = new(bl.x + size.x - 1, bl.y);
            Vector2Int tl = new(bl.x, bl.y + size.y - 1);
            Vector2Int tr = new(br.x, tl.y);
            List<Tile> tiles = new()
        {
            LevelGenerator.Level.TileMap.Get(bl),
            LevelGenerator.Level.TileMap.Get(br),
            LevelGenerator.Level.TileMap.Get(tl),
            LevelGenerator.Level.TileMap.Get(tr),
        };
            foreach (Tile tile in tiles)
            {
                TryChange(tile, TileType.ROOM_CORNER);
            }
        }

        private void TryChange(Tile tile, TileType nextType)
        {
            bool noType = tile.Type == default;
            //bool isRoom = TileType.IsRoom(tile.Type);
            bool isRoomArea = tile.Type == TileType.ROOM_AREA;
            bool isRoomBorder = tile.Type == TileType.ROOM_BORDER;
            bool isRoomCorner = tile.Type == TileType.ROOM_CORNER;
            bool roomOk = !isRoomArea && !isRoomCorner;
            //if (noType || roomOk)
            if (noType || isRoomBorder)
            //if (noType)
            {
                tile.Type = nextType;
            }
        }
    }
}
