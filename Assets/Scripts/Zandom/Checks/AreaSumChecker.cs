using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSumChecker : LevelGeneratorCheck
{
    public AreaSumChecker(LevelGenerator levelGenerator)
    {
        Rooms = levelGenerator.Level.Rooms.Values;
        Area = Get();
    }

    public IEnumerable<Room> Rooms { get; }
    public int Area { get; }

    public bool CheckMin(int minimum)
    {
        return Area >= minimum;
    }

    public bool CheckMax(int maximum)
    {
        return Area <= maximum;
    }

    private int Get()
    {
        int levelArea = 0;
        foreach (var item in Rooms)
        {
            levelArea += item.Area;
        }
        return levelArea;
    }
}
