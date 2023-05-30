using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Factories
{
    public class TilePlanFactory
    {
        public TilePlanFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }
        
        public TilePlan Create(Vector3Int coordinates)
        {
            bool exists = LevelPlan.Tiles.TryGetValue(coordinates, out TilePlan result);
            if (!exists)
            {
                result = new(LevelPlan, coordinates);
                LevelPlan.Tiles.Add(coordinates, result);
            }
            return result;
        }

        public Dictionary<Vector3Int, TilePlan> Create(IEnumerable<Vector3Int> coordinates)
        {
            Dictionary<Vector3Int, TilePlan> result = new();
            foreach (Vector3Int coord in coordinates)
            {
                TilePlan tile = Create(coord);
                result.Add(coord, tile);
            }
            return result;
        }
    }
}
