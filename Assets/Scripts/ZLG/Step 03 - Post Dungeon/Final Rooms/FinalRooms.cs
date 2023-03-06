using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRooms : LevelGeneratorTask
{
    public FinalRooms(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override void Run()
    {
        //LevelPostGen levelLayout = levelStyle.LevelLayout;
        foreach (Room room in LevelGenerator.Level.Rooms.Values)
        {
            Run(room);
            //FinalRoom finalRoom = Run(room);
            //levelLayout.AddRoom(finalRoom);
        }
    }

    public void Run(Room room)
    {
        FinalRoom parent = room.Parent?.GeneratedRoom;
        FinalLevel finalLevel = LevelGenerator.FinalLevel;
        Transform parentTransform = finalLevel.transform;
        finalLevel.CreateFinalRoom(room, parent, parentTransform);
    }
}
