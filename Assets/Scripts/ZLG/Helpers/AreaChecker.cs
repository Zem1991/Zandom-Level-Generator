using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AreaChecker
{
    public AreaChecker(LevelGenerator levelGenerator)
    {
        Rooms = levelGenerator.Level.Rooms.Values;
    }

    public AreaChecker(IEnumerable<Room> rooms)
    {
        Rooms = rooms;
    }

    private IEnumerable<Room> Rooms { get; }

    public int GetArea()
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
        current = GetArea();
        return CheckMin(current, out minimum);
    }

    public bool CheckMin(int current, out int minimum)
    {
        minimum = Constants.LEVEL_AREA_MIN;
        return current >= minimum;
    }

    public bool CheckMax(out int current, out int maximum)
    {
        current = GetArea();
        return CheckMax(current, out maximum);
    }

    public bool CheckMax(int current, out int maximum)
    {
        maximum = Constants.LEVEL_AREA_MAX;
        return current <= maximum;
    }
}
