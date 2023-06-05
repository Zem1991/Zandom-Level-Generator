using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class PointOfInterestFactory
    {
        public PointOfInterestFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public int NextId()
        {
            return LevelPlan.PointsOfInterest.Count;
        }
        
        public PointOfInterest Create(int id, string name, Vector3 position, Obstacle obstacle = null)
        {
            bool exists = LevelPlan.PointsOfInterest.TryGetValue(id, out PointOfInterest result);
            if (!exists)
            {
                result = new(LevelPlan, id, name, position, obstacle);
                LevelPlan.PointsOfInterest.Add(id, result);
            }
            return result;
        }
    }
}
