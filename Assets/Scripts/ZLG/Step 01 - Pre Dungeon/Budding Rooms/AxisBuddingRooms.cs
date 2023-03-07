using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AxisBuddingRooms
{
    public AxisBuddingRooms(LevelGenerator levelGenerator)
    {
        LevelGenerator = levelGenerator;
    }

    protected LevelGenerator LevelGenerator { get; }

    protected List<Room> Run(Vector2Int position1, Vector2Int position2, Vector2Int size, bool vertical, Room parent)
    {
        BuddingRoomsExecutor buddingRoomsExecutor = new BuddingRoomsExecutor(LevelGenerator);
        Room room1 = buddingRoomsExecutor.Run(position1, size, vertical, parent);
        Room room2 = buddingRoomsExecutor.Run(position2, size, vertical, parent);
        List<Room> result = new();
        if (room1 != null) result.Add(room1);
        if (room2 != null) result.Add(room2);
        return result;
    }
}
