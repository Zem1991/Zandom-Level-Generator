using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSumChecker
{
    public AreaSumChecker(LevelGenerator levelGenerator)
    {
        Rooms = levelGenerator.Level.Rooms.Values;
    }

    public AreaSumChecker(IEnumerable<Room> rooms)
    {
        Rooms = rooms;
    }

    private IEnumerable<Room> Rooms { get; }

    public int Get()
    {
        int levelArea = 0;
        foreach (var item in Rooms)
        {
            levelArea += item.Area;
        }
        return levelArea;
    }

    public bool CheckMin(out int current, out int minimum)
    {
        current = Get();
        return CheckMin(current, out minimum);
    }

    public bool CheckMin(int current, out int minimum)
    {
        minimum = Constants.LEVEL_AREA_MIN;
        return current >= minimum;
    }

    public bool CheckMax(out int current, out int maximum)
    {
        current = Get();
        return CheckMax(current, out maximum);
    }

    public bool CheckMax(int current, out int maximum)
    {
        maximum = Constants.LEVEL_AREA_MAX;
        return current <= maximum;
    }
}
