using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallFinder : LevelGeneratorTask
{
    private Dictionary<(Room, Room), List<Tile>> roomsTiles;

    public WallFinder(LevelGenerator levelGenerator) : base(levelGenerator)
    {
        roomsTiles = new();
    }

    public override void Run()
    {
        IterateTiles();
        BuildWalls();
    }

    private void IterateTiles()
    {
        Vector2Int start = new();
        Vector2Int size = Vector2Int.one * Constants.LEVEL_SIZE;
        bool wallTile(int col, int row)
        {
            Vector2Int coordinates = new(col, row);
            Tile tile = LevelGenerator.Level.TileMap.Get(coordinates);
            if (tile == null) return false;
            if (tile.Type != TileType.ROOM_BORDER) return false;
            if (tile.MentionedRooms.Count != 2) return false;
            Room sourceRoom = tile.MentionedRooms[0];
            Room neighborRoom = tile.MentionedRooms[1];
            (Room, Room) rooms = (sourceRoom, neighborRoom);
            bool hadList = roomsTiles.TryGetValue(rooms, out List<Tile> tiles);
            if (!hadList)
            {
                tiles = new();
                roomsTiles.Add(rooms, tiles);
            }
            tiles.Add(tile);
            return true;
        }
        TileMapIterator iterator = new(false);
        iterator.IterateAll(start, size, wallTile);
    }

    private void BuildWalls()
    {
        WallBuilder builder = new(LevelGenerator);
        foreach (var item in roomsTiles)
        {
            (Room, Room) rooms = item.Key;
            List<Tile> tiles = Sort(item.Value);
            bool can = builder.CanBuild(rooms.Item1, rooms.Item2, tiles);
            if (!can) continue;
            builder.Build(rooms.Item1, rooms.Item2, tiles);
        }
    }

    private List<Tile> Sort(List<Tile> tiles)
    {
        tiles = tiles.OrderBy(tile => tile.Coordinates.x).ToList();
        tiles = tiles.OrderBy(tile => tile.Coordinates.y).ToList();
        return tiles;
    }
}
