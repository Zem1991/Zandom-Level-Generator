using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFinalTiles : LevelGeneratorTask
{
    public GenerateFinalTiles(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override IEnumerator Run()
    {
        Vector2Int start = new();
        Vector2Int size = Vector2Int.one * Constants.LEVEL_SIZE_MAX;
        start -= Vector2Int.one;
        size += Vector2Int.one * 2;
        bool finalTile(int col, int row)
        {
            Vector2Int coordinates = new(col, row);
            Tile tile = LevelGenerator.Level.TileMap.Get(coordinates);
            if (tile == null) return false;

            TileType tileType = tile.Type;
            GameObject model = LevelGenerator.ZandomTileset.GetModel(tileType);
            if (!model) return false;

            Room room = tile.MentionedRooms[0];
            FinalRoom finalRoom = room.GeneratedRoom;
            Vector3 finalRoomposition = finalRoom.transform.position;

            Vector3 position = finalRoomposition + new Vector3(coordinates.x, 0, coordinates.y);
            GameObject finalTile = Object.Instantiate(model, position, Quaternion.identity, finalRoom.transform);
            //finalRoom.AddTile(finalTile);
            finalTile.name = $"\'{tile.Type}\' {coordinates}";
            tile.GeneratedTile = finalTile;
            return true;
        }
        TileMapIterator iterator = new(false);
        iterator.IterateAll(start, size, finalTile);
        yield return null;
    }
}
