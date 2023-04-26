using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFinalTiles : LevelGeneratorTask
{
    public GenerateFinalTiles(LevelGenerator levelGenerator) : base(levelGenerator)
    {
        int size = Constants.LEVEL_SIZE_MAX;
        Start = new();
        Size = new(size, size);
    }

    public GenerateFinalTiles(LevelGenerator levelGenerator, Room room) : this(levelGenerator)
    {
        Start = room.Start;
        Size = room.Size;
        Start -= Vector2Int.one;
        Size += Vector2Int.one * 2;
        TargetRoom = room;
    }

    public Vector2Int Start { get; }
    public Vector2Int Size { get; }
    public Room TargetRoom { get; }

    public override IEnumerator Run()
    {
        //Vector2Int start = new();
        //Vector2Int size = Vector2Int.one * Constants.LEVEL_SIZE_MAX;
        //start -= Vector2Int.one;
        //size += Vector2Int.one * 2;
        bool finalTile(int col, int row)
        {
            Vector2Int coordinates = new(col, row);
            Tile tile = LevelGenerator.Level.TileMap.Get(coordinates);
            if (tile == null) return false;

            TileType tileType = tile.Type;
            GameObject model = LevelGenerator.ZandomTileset.GetModel(tileType);
            if (!model) return false;

            Room room = tile.MentionedRooms[0];
            bool hasTargetRoom = TargetRoom != null;
            if (hasTargetRoom && room != TargetRoom)
            {
                //Attempting to generate a FinalRoom using a FinalTile that will end up in another FinalRoom later.
                return false;
            }

            FinalRoom finalRoom = room.GeneratedRoom;
            Vector3 finalRoomposition = finalRoom.transform.position;
            Vector3 position = finalRoomposition + new Vector3(coordinates.x, 0, coordinates.y);

            GameObject currentFinalTile = tile.GeneratedTile;
            if (currentFinalTile) Object.Destroy(currentFinalTile);
            GameObject finalTile = Object.Instantiate(model, position, Quaternion.identity, finalRoom.transform);
            
            //finalRoom.AddTile(finalTile);
            finalTile.name = $"\'{tile.Type}\' {coordinates}";
            tile.GeneratedTile = finalTile;
            return true;
        }
        TileMapIterator iterator = new(false);
        iterator.IterateAll(Start, Size, finalTile);
        yield return null;
    }
}
