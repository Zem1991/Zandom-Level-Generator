using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Task;

namespace ZandomLevelGenerator.Components
{
    public abstract class ZandomStyle : MonoBehaviour
    {
        //Walkable areas
        public abstract List<LevelGeneratorTask> Step01_Tasks(LevelGenerator levelGenerator);
        public abstract bool Step01_Checks(LevelGenerator levelGenerator, out string message);

        //Level details
        public abstract List<LevelGeneratorTask> Step02_Tasks(LevelGenerator levelGenerator);
        public abstract bool Step02_Checks(LevelGenerator levelGenerator, out string message);

        //Object placement
        public abstract List<LevelGeneratorTask> Step03_Tasks(LevelGenerator levelGenerator);
        public abstract bool Step03_Checks(LevelGenerator levelGenerator, out string message);
    }
}
