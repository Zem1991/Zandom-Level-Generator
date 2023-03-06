using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTypeRandomizer : LevelGeneratorTask
{
    public DoorTypeRandomizer(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override void Run()
    {
        //foreach (Wall wall in LevelGenerator.Level.Walls.Values)
        //{
        //    if (wall.IsParentWall()) parentWalls.Add(wall);
        //    else if (wall.IsDifferentRoot()) differentRoots.Add(wall);
        //    else others.Add(wall);
        //    Run(wall);
        //}
    }

    private void Run(Wall wall)
    {
        foreach (Tile tile in wall.Tiles)
        {
            if (tile.Type == TileTypes.DOOR) tile.Type = wall.Type;
        }
    }
}
