using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class LevelPlanFactory
    {
        public LevelPlan Create()
        {
            LevelPlan result = new();
            return result;
        }
    }
}