using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        
        public bool IsAvailable(HashSet<Vector3Int> coordinates)
        {
            foreach (var item in coordinates)
            {
                bool occupied = LevelPlan.Tiles.TryGetValue(item, out TilePlan tile);
                if (occupied) return false;
            }
            return true;
        }
    }
}
