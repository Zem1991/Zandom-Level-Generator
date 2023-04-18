using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoomSumChecker
{
    public SpecialRoomSumChecker(LevelGenerator levelGenerator)
    {
        Rooms = levelGenerator.Level.Rooms.Values;
    }

    public SpecialRoomSumChecker(IEnumerable<Room> rooms)
    {
        Rooms = rooms;
    }

    private IEnumerable<Room> Rooms { get; }

    public int Get()
    {
        List<Room> result = new();
        foreach (var item in Rooms)
        {
            if (item.Type != RoomType.SPECIAL) continue;
            result.Add(item);
        }
        return result.Count;
    }

    public bool CheckMin(out int current, out int minimum)
    {
        current = Get();
        return CheckMin(current, out minimum);
    }

    public bool CheckMin(int current, out int minimum)
    {
        minimum = Constants.SPECIAL_ROOM_MIN;
        return current >= minimum;
    }
}
