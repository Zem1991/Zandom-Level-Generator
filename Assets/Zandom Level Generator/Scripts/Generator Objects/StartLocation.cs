using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class StartLocation : PointOfInterest
    {
        public StartLocation(LevelPlan levelPlan, Vector3 position, Obstacle obstacle = null) : base(levelPlan, 0, Constants.ZandomStartLocation, position, obstacle)
        {
        }
    }
}
