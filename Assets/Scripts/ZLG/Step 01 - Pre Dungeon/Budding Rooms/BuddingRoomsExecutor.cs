using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddingRoomsExecutor
{
    public BuddingRoomsExecutor(LevelGenerator levelGenerator)
    {
        LevelGenerator = levelGenerator;
    }

    protected LevelGenerator LevelGenerator { get; }

    public Room Run(Vector2Int position, Vector2Int size, bool vertical, Room parent)
    {
        RoomBuilder roomBuilder = new(LevelGenerator);
        Room result = roomBuilder.CanBuild(position, size) ? roomBuilder.Build(position, size, vertical, parent) : null;
        return result;
    }
}
