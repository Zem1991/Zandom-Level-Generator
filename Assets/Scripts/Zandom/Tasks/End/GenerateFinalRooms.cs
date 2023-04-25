using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFinalRooms : LevelGeneratorTask
{
    public GenerateFinalRooms(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override IEnumerator Run()
    {
        //LevelPostGen levelLayout = levelStyle.LevelLayout;
        foreach (Room room in LevelGenerator.Level.Rooms.Values)
        {
            Run(room);
            //FinalRoom finalRoom = Run(room);
            //levelLayout.AddRoom(finalRoom);
        }
        yield return null;
    }

    public void Run(Room room)
    {
        FinalRoom parent = room.Parent?.GeneratedRoom;
        FinalLevel finalLevel = LevelGenerator.FinalLevel;
        finalLevel.CreateFinalRoom(room, parent);
    }
}
