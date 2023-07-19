using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class LevelPlanFactory
    {
        public LevelPlan Create(AsciiTable asciiTable)
        {
            LevelPlan result = new(asciiTable);
            return result;
        }
    }
}
