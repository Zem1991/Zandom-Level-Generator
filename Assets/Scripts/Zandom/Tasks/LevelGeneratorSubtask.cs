using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelGeneratorSubtask
{
    public LevelGeneratorSubtask(LevelGenerator levelGenerator)
    {
        LevelGenerator = levelGenerator;
    }

    protected LevelGenerator LevelGenerator { get; }

    public void Wait()
    {
        //if (!LevelGenerator.waitSubtasks) return;
        //System.
    }
}
