using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFinalRoom : LevelGeneratorTask
{
    public GenerateFinalRoom(LevelGenerator levelGenerator, Room room) : base(levelGenerator)
    {
        Room = room;
    }

    public Room Room { get; }

    public override IEnumerator Run()
    {
        FinalRoom generatedRoom = Room.GeneratedRoom;
        if (!generatedRoom)
        {
            FinalRoom parent = Room.Parent?.GeneratedRoom;
            FinalLevel finalLevel = LevelGenerator.FinalLevel;
            finalLevel.CreateFinalRoom(Room, parent);
        }
        yield return new GenerateFinalTiles(LevelGenerator, Room).Run();
    }
}
