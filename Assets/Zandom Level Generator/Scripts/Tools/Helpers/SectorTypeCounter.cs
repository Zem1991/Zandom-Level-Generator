using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class SectorTypeCounter
    {
        public int CountType(SectorType type, LevelPlan levelPlan)
        {
            List<SectorPlan> sectorPlanList = levelPlan.Sectors.Values.ToList();
            return CountType(type, sectorPlanList);
        }

        public int CountType(SectorType type, List<SectorPlan> sectorPlanList)
        {
            int count = 0;
            foreach (var item in sectorPlanList)
            {
                SectorType sectorType = item.Type;
                if (sectorType != type) continue;
                count++;
            }
            return count;
        }
    }
}
