using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelGeneratorTask
{
    public LevelGeneratorTask(LevelGenerator levelGenerator)
    {
        LevelGenerator = levelGenerator;
    }

    protected LevelGenerator LevelGenerator { get; }

    public abstract IEnumerator Run();
}
