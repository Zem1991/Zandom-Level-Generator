using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tools.Checkers
{
    public class SafetyBoundsChecker
    {
        public StyleParameters StyleParameters { get; }

        public SafetyBoundsChecker(StyleParameters styleParameters)
        {
            StyleParameters = styleParameters;
        }

        public bool IsOutsideBounds(SectorPlan sectorPlan)
        {
            Vector3 center = new PositionGetter().GetCenter(sectorPlan);
            Vector3Int levelMin = GetMin();
            Vector3Int levelMax = GetMax();
            if (center.x < levelMin.x) return true;
            if (center.z < levelMin.z) return true;
            if (center.x > levelMax.x) return true;
            if (center.z > levelMax.z) return true;
            return false;
        }

        private Vector3Int GetMin()
        {
            return StyleParameters.SafetySize;
        }

        private Vector3Int GetMax()
        {
            Vector3Int resullt = GetMin();
            //TODO: remove hardcoded 7
            resullt *= 7;
            resullt -= StyleParameters.SafetySize;
            return resullt;
        }
    }
}
