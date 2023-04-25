using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZandomStateEnd : ZandomState
{
    public ZandomStateEnd(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override ZandomStateName Name => ZandomStateName.END;

    public override ZandomState NextIfFailure()
    {
        return null;
    }

    public override ZandomState NextIfSuccess()
    {
        return null;
    }

    protected override List<LevelGeneratorTask> GetTasks()
    {
        LevelGenerator.FinalLevel.Clear();
        return new()
        {
            new GenerateFinalRooms(LevelGenerator),
            new GenerateFinalTiles(LevelGenerator),
            new GenerateFinalObstacles(LevelGenerator),
        };
    }

    protected override bool GetChecks(out string message)
    {
        //message = $"Level generation finished!";
        message = null;
        return true;
    }
}
