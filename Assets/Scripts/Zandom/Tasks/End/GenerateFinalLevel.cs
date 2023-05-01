using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFinalLevel : LevelGeneratorTask
{
    public GenerateFinalLevel(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override IEnumerator Run()
    {
        Level level = LevelGenerator.Level;
        if (LevelGenerator.taskWaitingTier > 0)
        {
            Debug.LogWarning("Some generator tasks can be producing duplicate results because taskWaitingTier > 0.");
        }
        foreach (Room room in level.Rooms.Values)
        {
            yield return new GenerateFinalRoom(LevelGenerator, room).Run();
        }
        yield return new GenerateFinalTiles(LevelGenerator).Run();
        yield return new GenerateFinalObstacles(LevelGenerator).Run();
    }
}
