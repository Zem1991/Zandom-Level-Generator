using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTiles : LevelGeneratorTask
{
    public FinalTiles(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override void Run()
    {
        Vector2Int start = new();
        Vector2Int size = Vector2Int.one * Constants.LEVEL_SIZE;
        start -= Vector2Int.one;
        size += Vector2Int.one * 2;
        bool finalTile(int col, int row)
        {
            Vector2Int coordinates = new(col, row);
            Tile tile = LevelGenerator.Level.TileMap.Get(coordinates);
            if (tile == null) return false;

            TileType tileType = tile.Type;
            GameObject model = LevelGenerator.LevelGeneratorStyle.GetModel(tileType);
            if (!model) return false;

            Room room = tile.MentionedRooms[0];
            FinalRoom finalRoom = room.GeneratedRoom;
            Vector3 finalRoomposition = finalRoom.transform.position;

            Vector3 position = finalRoomposition + new Vector3(coordinates.x, 0, coordinates.y);
            GameObject finalTile = Object.Instantiate(model, position, Quaternion.identity, finalRoom.transform);
            //finalRoom.AddTile(finalTile);
            finalTile.name = $"\'{tile.Type}\' {coordinates}";
            return true;
        }
        TileMapIterator iterator = new(false);
        iterator.IterateAll(start, size, finalTile);
    }
}
