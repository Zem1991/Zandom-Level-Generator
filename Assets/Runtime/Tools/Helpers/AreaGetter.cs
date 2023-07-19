using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class AreaGetter
    {
        public int GetArea(LevelPlan levelPlan)
        {
            List<SectorPlan> sectorPlanList = levelPlan.Sectors.Values.ToList();
            return GetArea(sectorPlanList);
        }

        public int GetArea(List<SectorPlan> sectorPlanList)
        {
            int levelArea = 0;
            foreach (var item in sectorPlanList)
            {
                levelArea += GetArea(item);
            }
            return levelArea;
        }

        public int GetArea(SectorPlan sectorPlan)
        {
            return sectorPlan.TilesIds.Count;
        }
    }
}
