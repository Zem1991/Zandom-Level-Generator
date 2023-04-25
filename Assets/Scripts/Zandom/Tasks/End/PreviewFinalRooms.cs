using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewFinalRooms : LevelGeneratorTask
{
    public PreviewFinalRooms(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override IEnumerator Run()
    {
        LevelGenerator.FinalLevel.Clear();
        yield return new GenerateFinalRooms(LevelGenerator).Run();
        yield return new GenerateFinalTiles(LevelGenerator).Run();
    }
}
