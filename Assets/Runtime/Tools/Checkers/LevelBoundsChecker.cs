using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;

namespace ZandomLevelGenerator.Tools.Checkers
{
    public class LevelBoundsChecker
    {
        public StyleParameters StyleParameters { get; }

        public LevelBoundsChecker(StyleParameters styleParameters)
        {
            StyleParameters = styleParameters;
        }

        public bool IsOutsideBounds(Vector3Int coordinates)
        {
            return IsOutsideBounds(coordinates, Vector3Int.one);
        }

        public bool IsOutsideBounds(Vector3Int start, Vector3Int size)
        {
            int roomEndX = start.x + size.x - 1;
            int roomEndZ = start.z + size.z - 1;
            Vector3Int levelMin = GetMin();
            Vector3Int levelMax = GetMax();
            if (start.x < levelMin.x) return true;
            if (start.z < levelMin.z) return true;
            if (roomEndX > levelMax.x) return true;
            if (roomEndZ > levelMax.z) return true;
            return false;
        }

        private Vector3Int GetMin()
        {
            return Vector3Int.zero;
        }

        private Vector3Int GetMax()
        {
            return StyleParameters.LevelSize;
        }
    }
}
