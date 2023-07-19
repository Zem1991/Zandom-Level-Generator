using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class ObstacleFactory
    {
        public ObstacleFactory(StyleParameters styleParameters, LevelPlan levelPlan)
        {
            StyleParameters = styleParameters;
            LevelPlan = levelPlan;
        }

        public StyleParameters StyleParameters { get; }
        public LevelPlan LevelPlan { get; }

        public int NextId()
        {
            return LevelPlan.Obstacles.Count;
        }
        
        public Obstacle Create(int id, HashSet<Vector3Int> tilesIds, Vector3 rotationEuler, ObstacleData data)
        {
            bool exists = LevelPlan.Obstacles.TryGetValue(id, out Obstacle result);
            if (!exists)
            {
                result = new(LevelPlan, id, tilesIds, rotationEuler, data);
                LevelPlan.Obstacles.Add(id, result);
            }
            new ObstacleToTilesLinker(StyleParameters, LevelPlan).LinkIds(result);
            return result;
        }
    }
}
