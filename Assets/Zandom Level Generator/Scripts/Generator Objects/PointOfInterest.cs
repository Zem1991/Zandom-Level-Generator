using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class PointOfInterest
    {
        public PointOfInterest(LevelPlan levelPlan, int id, string name, Vector3 position, Obstacle obstacle = null)
        {
            LevelPlan = levelPlan;
            Id = id;
            Name = name;
            Position = position;
            ObstacleId = obstacle?.Id ?? -1;
        }

        public LevelPlan LevelPlan { get; }
        public int Id { get; }
        public string Name { get; }
        public Vector3 Position { get; }

        public int ObstacleId { get; set; }
        public ZandomPointOfInterest Result { get; set; }

        public override string ToString()
        {
            return $"PointOfInterest #{Id} \'{Name}\'";
        }

        public bool HasObstacle()
        {
            return ObstacleId >= 0;
        }
    }
}
