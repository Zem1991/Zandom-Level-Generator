using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CathedralSpecialRooms : LevelGeneratorTask
{
    public CathedralSpecialRooms(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override void Run()
    {
        List<Room> Rooms = new(LevelGenerator.Level.Rooms.Values);
        foreach (var item in Rooms)
        {
            if (!item.IsEnclosed()) continue;
            item.Type = RoomType.SPECIAL;
        }
    }
}
