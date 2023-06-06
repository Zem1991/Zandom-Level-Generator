using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class ObstacleFactory
    {
        public ObstacleFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public int NextId()
        {
            return LevelPlan.Obstacles.Count;
        }
        
        public Obstacle Create(int id, HashSet<Vector3Int> tilesIds, ObstacleData data)
        {
            bool exists = LevelPlan.Obstacles.TryGetValue(id, out Obstacle result);
            if (!exists)
            {
                result = new(LevelPlan, id, tilesIds, data);
                LevelPlan.Obstacles.Add(id, result);
            }
            new ObstacleToTilesLinker(LevelPlan).LinkIds(result);
            return result;
        }
    }
}
