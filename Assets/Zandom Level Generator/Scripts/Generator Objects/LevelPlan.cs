using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            StartLocation = null;
        }

        public Dictionary<Vector3Int, TilePlan> Tiles { get; private set; }
        public Dictionary<int, SectorPlan> Sectors { get; private set; }
        public Dictionary<int, Obstacle> Obstacles { get; private set; }
        public Dictionary<int, PointOfInterest> PointsOfInterest { get; private set; }
        public StartLocation StartLocation { get; private set; }
    }
}
