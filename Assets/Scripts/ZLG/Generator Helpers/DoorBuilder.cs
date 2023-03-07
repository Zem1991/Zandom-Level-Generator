using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBuilder
{
    public DoorBuilder(LevelGenerator levelGenerator)
    {
        LevelGenerator = levelGenerator;
    }

    private LevelGenerator LevelGenerator { get; }

    public bool CanBuild(Wall wall)
    {
        return !TileTypes.IsFloor(wall.Type);
    }

    public Wall Build(Wall wall)
    {
        DoorSizePicker sizePicker = new();
        int doorSize = sizePicker.Pick(wall);
        int validLength = wall.Tiles.Count - doorSize + 1;// - 2;
        int startPos = Random.Range(0, validLength);
        int endPos = startPos + doorSize;
        for (int i = startPos; i < endPos; i++)
        {
            Tile tile = wall.Tiles[i];
            tile.Type = TileTypes.DOOR;
        }
        return wall;
    }
}
