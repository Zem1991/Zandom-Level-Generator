using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class PositionGetter
    {
        //public PositionGetter(LevelPlan levelPlan)
        //{
        //    LevelPlan = levelPlan;
        //}

        //public LevelPlan LevelPlan { get; }

        public Vector3 GetCenter(SectorPlan sectorPlan)
        {
            Vector3 result = new();
            foreach (var item in sectorPlan.TilesIds)
            {
                result += item;
            }
            result /= sectorPlan.TilesIds.Count;
            return result;
        }

        public Vector3 GetCenter(IEnumerable<TilePlan> tiles)
        {
            IEnumerable<Vector3Int> coordinates = tiles.Select(item => item.Coordinates);
            return GetCenter(coordinates);
        }

        public Vector3 GetCenter(IEnumerable<Vector3Int> coordinates)
        {
            Vector3 result = new();
            foreach (var item in coordinates)
            {
                result.x += item.x;
                result.z += item.y;
            }
            result /= coordinates.Count();
            return result;
        }
    }
}
