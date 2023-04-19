using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : LevelGeneratorTask
{
    public DoorSpawner(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override void Run()
    {
        foreach (Wall wall in LevelGenerator.Level.Walls.Values)
        {
            if (!wall.CanHaveDoor()) continue;
            Run(wall);
        }
    }

    public void Run(Wall wall)
    {
        DoorSizePicker sizePicker = new(LevelGenerator);
        int doorSize = sizePicker.Pick(wall);
        int validLength = wall.Tiles.Count - doorSize + 1;// - 2;
        int startPos = Random.Range(0, validLength);
        int endPos = startPos + doorSize;
        for (int i = startPos; i < endPos; i++)
        {
            Tile tile = wall.Tiles[i];
            tile.Type = TileType.DOOR;
        }
    }
}
