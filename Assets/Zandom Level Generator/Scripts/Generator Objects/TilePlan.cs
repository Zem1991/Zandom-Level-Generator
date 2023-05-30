using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class TilePlan
    {
        public TilePlan(LevelPlan levelPlan, Vector3Int coordinates)
        {
            Level = levelPlan;
            Coordinates = coordinates;
            SectorsIds = new();
        }

        public LevelPlan Level { get; }
        public Vector3Int Coordinates { get; }
        public HashSet<int> SectorsIds { get; }

        public int ObstacleId { get; set; }
        public TileTypeNew Type { get; set; }
        public string Code { get; set; }
        public ZandomTile Result { get; set; }

        public override string ToString()
        {
            return $"TilePlan {Coordinates} \'{Type}\' {Code}";
        }
    }
}
