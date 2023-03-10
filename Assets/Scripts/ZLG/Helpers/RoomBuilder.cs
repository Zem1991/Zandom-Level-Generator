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
        //start -= Vector2Int.one;
        //size += Vector2Int.one;
        return insideLevelBounds && availableOnTilemap;
    }

    public Room Build(Vector2Int start, SetPiece setPiece, bool vertical, Room parent)
    {
        Room room = Build(start, setPiece.Size, vertical, parent);
        SetPieceBuilder setPieceBuilder = new(LevelGenerator);
        setPieceBuilder.Build(start, setPiece);
        return room;
    }

    public Room Build(Vector2Int start, Vector2Int size, bool vertical, Room parent)
    {
        //Room root = parent?.Root ?? parent;
        //Room room = LevelGenerator.Level.CreateFinalRoom(start, size, vertical, root, parent);
        Room room = LevelGenerator.Level.CreateRoom(start, size, vertical, parent);
        BuildArea(room, start, size);
        BuildBorders(room, start, size);
        BuildCorners(room, start, size);
        return room;
    }

    private void BuildArea(Room room, Vector2Int start, Vector2Int size)
    {
        bool areaTile(int col, int row)
        {
            Vector2Int coordinates = new(col, row);
            Tile tile = LevelGenerator.Level.TileMap.Create(coordinates);
            //room.TileMap.Add(tile);
            room.Tiles.Add(tile);
            tile.MentionedRooms.Add(room);
            tile.Type = TileTypes.ROOM_AREA;
            return true;
        }
        TileMapIterator iterator = new();
        iterator.IterateAll(start, size, areaTile);
    }

    private void BuildBorders(Room room, Vector2Int start, Vector2Int size)
    {
        start -= Vector2Int.one;
        size += Vector2Int.one * 2;
        bool borderTile(int col, int row)
        {
            Vector2Int coordinates = new(col, row);
            bool alreadyHaveTile = LevelGenerator.Level.TileMap.Has(coordinates);
            Tile tile = LevelGenerator.Level.TileMap.Get(coordinates);
            if (tile == null)
            {
                tile = LevelGenerator.Level.TileMap.Create(coordinates);
                //room.TileMap.Add(tile);
                room.Tiles.Add(tile);
            }
            //else if (tile.Type != TileTypes.ROOM_BORDER)
            //{
            //    throw new System.Exception($"Border tile at {coordinates} would be invalid.");
            //}
            tile.MentionedRooms.Add(room);
            if (tile.Type != TileTypes.ROOM_CORNER)
            {
                tile.Type = TileTypes.ROOM_BORDER;
            }
            return true;
        }
        TileMapIterator iterator = new();
        iterator.IterateBorder(start, size, borderTile);
    }

    private void BuildCorners(Room room, Vector2Int start, Vector2Int size)
    {
        start -= Vector2Int.one;
        size += Vector2Int.one * 2;
        Vector2Int bl = start;
        Vector2Int br = new(bl.x + size.x - 1, bl.y);
        Vector2Int tl = new(bl.x, bl.y + size.y - 1);
        Vector2Int tr = new(br.x, tl.y);
        LevelGenerator.Level.TileMap.Get(bl).Type = TileTypes.ROOM_CORNER;
        LevelGenerator.Level.TileMap.Get(br).Type = TileTypes.ROOM_CORNER;
        LevelGenerator.Level.TileMap.Get(tl).Type = TileTypes.ROOM_CORNER;
        LevelGenerator.Level.TileMap.Get(tr).Type = TileTypes.ROOM_CORNER;
    }
}
