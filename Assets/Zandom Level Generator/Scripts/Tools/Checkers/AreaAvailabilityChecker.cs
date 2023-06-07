using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Checkers
{
    public class AreaAvailabilityChecker
    {
        public AreaAvailabilityChecker(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }
        
        public bool IsAvailableForTiles(HashSet<Vector3Int> coordinates)
        {
            foreach (var item in coordinates)
            {
                bool hasTile = LevelPlan.Tiles.TryGetValue(item, out TilePlan tile);
                if (!hasTile) continue;
                bool isArea = tile.Type == TileTypeNew.AREA;
                if (isArea) return false;
            }
            return true;
        }

        //public bool IsAvailableForObstacle(HashSet<Vector3Int> coordinates)
        //{
        //    foreach (var item in coordinates)
        //    {
        //        bool hasTile = LevelPlan.Tiles.TryGetValue(item, out TilePlan tile);
        //        if (!hasTile) return false;
        //        bool hasObstacle = tile.HasObstacle();
        //        if (hasObstacle) return false;
        //    }
        //    return true;
        //}
    }
}
