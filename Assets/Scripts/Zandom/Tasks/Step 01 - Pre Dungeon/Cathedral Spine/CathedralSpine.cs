using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CathedralSpine : LevelGeneratorTask
{
    public CathedralSpine(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }
    
    public override IEnumerator Run()
    {
        bool shorterVersion = LevelGenerator.ZandomParameters.avoidSizeBoundaries;
        int maxLength = shorterVersion ? 3 : 5;
        int corridorLength = Random.Range(0, maxLength);
        int maxPosition = maxLength - corridorLength;
        int firstRoomPosition = Random.Range(0, maxPosition);
        if (shorterVersion) firstRoomPosition++;
        bool vertical = Random.Range(0, 2) > 0;
        if (vertical) new VerticalCathedralSpine(LevelGenerator, firstRoomPosition, corridorLength).Run();
        else new HorizontalCathedralSpine(LevelGenerator, firstRoomPosition, corridorLength).Run();
        yield return null;
    }
}
