using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CathedralSpine : LevelGeneratorTask
{
    public CathedralSpine(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }
    
    public override void Run()
    {
        int corridorLength = Random.Range(0, 5);
        int maxPosition = 5 - corridorLength;
        int firstRoomPosition = Random.Range(0, maxPosition);
        bool vertical = Random.Range(0, 2) > 0;
        if (vertical) new VerticalCathedralSpine(LevelGenerator, firstRoomPosition, corridorLength).Run();
        else new HorizontalCathedralSpine(LevelGenerator, firstRoomPosition, corridorLength).Run();
    }
}
