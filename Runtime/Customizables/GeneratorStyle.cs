using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.Customizables
{
    public abstract class GeneratorStyle : MonoBehaviour
    {
        //Plan
        public abstract bool Step01_Checks(ZandomLevelGenerator zandomLevelGenerator, out string message);
        public abstract List<GeneratorTask> Step01_Tasks(ZandomLevelGenerator zandomLevelGenerator);

        //Build
        public abstract bool Step02_Checks(ZandomLevelGenerator zandomLevelGenerator, out string message);
        public abstract List<GeneratorTask> Step02_Tasks(ZandomLevelGenerator zandomLevelGenerator);

        //Decorate
        public abstract bool Step03_Checks(ZandomLevelGenerator zandomLevelGenerator, out string message);
        public abstract List<GeneratorTask> Step03_Tasks(ZandomLevelGenerator zandomLevelGenerator);
    }
}
