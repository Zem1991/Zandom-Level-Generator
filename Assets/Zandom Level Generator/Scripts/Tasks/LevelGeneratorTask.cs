using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Task
{
    public abstract class LevelGeneratorTask
    {
        public LevelGeneratorTask(LevelGenerator levelGenerator)
        {
            LevelGenerator = levelGenerator;
        }

        protected LevelGenerator LevelGenerator { get; }

        public abstract IEnumerator Run();
    }
}
