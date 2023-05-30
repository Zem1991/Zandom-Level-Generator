using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class LineSectorPlan : SectorPlan
    {
        public LineSectorPlan(LevelPlan levelPlan, int id, SectorPlan parent = null) : base(levelPlan, id, parent)
        {
        }
    }
}
