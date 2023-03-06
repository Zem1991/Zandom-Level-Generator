using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsFromWalls : LevelGeneratorTask
{
    public DoorsFromWalls(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override void Run()
    {
        DoorBuilder builder = new(LevelGenerator);
        foreach (Wall wall in LevelGenerator.Level.Walls.Values)
        {
            if (!builder.CanBuild(wall)) continue;
            builder.Build(wall);
        }
    }
}
