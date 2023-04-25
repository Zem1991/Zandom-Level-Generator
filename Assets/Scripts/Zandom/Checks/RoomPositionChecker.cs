using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPositionChecker : LevelGeneratorCheck
{
    public RoomPositionChecker(Level level)
    {
        Level = level;
    }

    public Level Level { get; }

    public bool CheckBoundsProximity(Room room)
    {
        Vector2Int roomMin = GetRoomMin(room);
        Vector2Int roomMax = GetRoomMax(room);
        Vector2Int levelMin = GetLevelMin();
        Vector2Int levelMax = GetLevelMax();
        if (roomMin.x < levelMin.x) return true;
        if (roomMin.y < levelMin.y) return true;
        if (roomMax.x > levelMax.x) return true;
        if (roomMax.y > levelMax.y) return true;
        return false;
    }

    private Vector2Int GetRoomMin(Room room)
    {
        int halfModule = Constants.MODULE_SIZE / 2;
        Vector2Int position = room.Start;
        position.x += halfModule;
        position.y += halfModule;
        return position;
    }

    private Vector2Int GetRoomMax(Room room)
    {
        int halfModule = Constants.MODULE_SIZE / 2;
        Vector2Int position = room.Start + room.Size;
        position.x -= halfModule;
        position.y -= halfModule;
        return position;
    }

    private Vector2Int GetLevelMin()
    {
        return Vector2Int.one * Constants.MODULE_SIZE;
    }

    private Vector2Int GetLevelMax()
    {
        Vector2Int resullt = GetLevelMin();
        resullt *= 7;
        resullt -= Vector2Int.one;
        return resullt;
    }
}
