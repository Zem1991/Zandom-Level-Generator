using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonAreaChecker
{
    private int roomSizeSum;

    public DungeonAreaChecker(LevelGenerator levelGenerator)
    {
        LevelGenerator = levelGenerator;
    }

    private LevelGenerator LevelGenerator { get; }
    
    public bool CheckAreaMin()
    {
        foreach (var item in LevelGenerator.Level.Rooms.Values)
        {
            roomSizeSum += item.Area;
        }
        return roomSizeSum >= Constants.DUNGEON_AREA_MIN;
    }
}
