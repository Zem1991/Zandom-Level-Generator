using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class LevelPlan
    {
        public LevelPlan()
        {
            Tiles = new();
            Sectors = new();
            Obstacles = new();
            PointsOfInterest = new();
        }

        public Dictionary<Vector3Int, TilePlan> Tiles { get; }
        public Dictionary<int, SectorPlan> Sectors { get; }
        public Dictionary<int, Obstacle> Obstacles { get; }
        public Dictionary<int, PointOfInterest> PointsOfInterest { get; }

        public StartLocation StartLocation { get; set; }
        public ZandomLevel Result { get; set; }

        public override string ToString()
        {
            return $"LevelPlan";
        }
    }
}
