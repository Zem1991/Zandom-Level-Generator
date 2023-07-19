using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class StartLocationFactory
    {
        public StartLocationFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }
        
        public StartLocation Create(Vector3 position, Obstacle obstacle = null)
        {
            StartLocation result = LevelPlan.StartLocation;
            if (result == null)
            {
                result = new(LevelPlan, position, obstacle);
                LevelPlan.StartLocation = result;
            }
            return result;
        }
    }
}
