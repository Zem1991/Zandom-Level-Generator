using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBuilder
{
    public RoomBuilder(LevelGenerator levelGenerator)
    {
        LevelGenerator = levelGenerator;
    }

    private LevelGenerator LevelGenerator { get; }

    public bool CanBuild(Vector2Int start, Vector2Int size)
    {
        bool insideLevelBounds = LevelGenerator.Level.IsInsideBounds(start, size);
        bool availableOnTilemap = LevelGenerator.Level.TileMap.IsAvailable(start, size);
        return insideLevelBounds && availableOnTilemap;
    }

    public Room Build(Vector2Int start, Vector2Int size, bool vertical, Room parent)
    {
        Room room = LevelGenerator.Level.CreateRoom(start, size, vertical, parent);
        bool areaTile(int col, int row)
        {
            Vector2Int coordinates = new(col, row);
            Tile tile = LevelGenerator.Level.TileMap.Create(coordinates);
            //room.TileMap.Add(tile);
            room.Tiles.Add(tile);
            tile.MentionedRooms.Add(room);
            tile.Type = TileType.ROOM_AREA;
            return true;
        }
        TileMapIterator iterator = new();
        iterator.IterateAll(start, size, areaTile);
        return room;
    }

    public Room Build(Vector2Int start, SetPiece setPiece, bool vertical, Room parent)
    {
        Room room = Build(start, setPiece.Size, vertical, parent);
        room.FromSetPiece = true;
        return room;
    }
}
