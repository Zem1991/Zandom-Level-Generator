using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class CoordinatesGetter
    {
        public HashSet<Vector3Int> Get(Vector3Int start, Vector3Int size)
        {
            HashSet<Vector3Int> result = new();
            BoundsInt boundsInt = new(start, size);
            foreach (Vector3Int point in boundsInt.allPositionsWithin)
            {
                result.Add(point);
            }
            return result;
        }
    }
}
