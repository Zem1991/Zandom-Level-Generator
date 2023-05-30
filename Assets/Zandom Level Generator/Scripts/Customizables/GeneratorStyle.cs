using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Customizables
{
    public abstract class GeneratorStyle
    {
        //Walkable areas
        public abstract List<GeneratorTask> Step01_Tasks(ZandomLevelGenerator zandomLevelGenerator);
        public abstract bool Step01_Checks(ZandomLevelGenerator zandomLevelGenerator, out string message);

        //Level details
        public abstract List<GeneratorTask> Step02_Tasks(ZandomLevelGenerator zandomLevelGenerator);
        public abstract bool Step02_Checks(ZandomLevelGenerator zandomLevelGenerator, out string message);

        //Object placement
        public abstract List<GeneratorTask> Step03_Tasks(ZandomLevelGenerator zandomLevelGenerator);
        public abstract bool Step03_Checks(ZandomLevelGenerator zandomLevelGenerator, out string message);
    }
}
