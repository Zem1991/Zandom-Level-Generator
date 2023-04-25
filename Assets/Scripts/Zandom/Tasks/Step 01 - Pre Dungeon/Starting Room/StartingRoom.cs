using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRoom : LevelGeneratorTask
{
    public StartingRoom(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override IEnumerator Run()
    {
        RoomBuilder roomBuilder = new(LevelGenerator);
        Vector2Int start = new(30, 30);
        Vector2Int size = new(20, 20);
        bool can = roomBuilder.CanBuild(start, size);
        if (can)
        {
            Room result = roomBuilder.Build(start, size, false, null);
            ApplyBorders applyBorders = new(LevelGenerator);
            applyBorders.Apply(result);
        }
        yield return null;
    }
}
