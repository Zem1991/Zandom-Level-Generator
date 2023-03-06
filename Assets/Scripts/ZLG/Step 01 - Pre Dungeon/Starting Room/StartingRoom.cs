using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRoom : LevelGeneratorTask
{
    public StartingRoom(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override void Run()
    {
        RoomBuilder roomBuilder = new(LevelGenerator);
        Vector2Int start = new(30, 30);
        Vector2Int size = new(20, 20);
        bool can = roomBuilder.CanBuild(start, size);
        if (!can) return;
        roomBuilder.Build(start, size, false, null);
    }
}
