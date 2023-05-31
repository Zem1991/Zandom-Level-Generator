using System.Collections;
using System.Collections.Generic;
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

        public Vector3 GetCenter(List<TilePlan> tiles)
        {
            Vector3 result = new();
            foreach (var item in tiles)
            {
                result.x += item.Coordinates.x;
                result.z += item.Coordinates.y;
            }
            result /= tiles.Count;
            return result;
        }
    }
}
