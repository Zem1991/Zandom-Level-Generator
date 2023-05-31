using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tools.Checkers
{
    public class SafetyBoundsChecker
    {
        public bool IsWithinSafetyBounds(SectorPlan sectorPlan)
        {
            Vector3 center = new PositionGetter().GetCenter(sectorPlan);
            Vector3Int levelMin = GetLevelMin();
            Vector3Int levelMax = GetLevelMax();
            if (center.x < levelMin.x) return true;
            if (center.z < levelMin.z) return true;
            if (center.x > levelMax.x) return true;
            if (center.z > levelMax.z) return true;
            return false;
        }

        private Vector3Int GetLevelMin()
        {
            return Vector3Int.one * Constants.MODULE_SIZE;
        }

        private Vector3Int GetLevelMax()
        {
            Vector3Int resullt = GetLevelMin();
            resullt *= 7;
            resullt -= Vector3Int.one;
            return resullt;
        }
    }
}
