using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class LevelPlan
    {
        public LevelPlan(AsciiTable asciiTable)
        {
            AsciiTable = asciiTable;
            Tiles = new();
            Sectors = new();
            BorderOverlapWalls = new();
            BorderOverlapDoorways = new();
            Obstacles = new();
            PointsOfInterest = new();
        }

        public AsciiTable AsciiTable { get; }
        public Dictionary<Vector3Int, TilePlan> Tiles { get; }
        public Dictionary<int, SectorPlan> Sectors { get; }
        public Dictionary<int, BorderOverlapWall> BorderOverlapWalls { get; }
        public Dictionary<int, BorderOverlapDoorway> BorderOverlapDoorways { get; }
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
