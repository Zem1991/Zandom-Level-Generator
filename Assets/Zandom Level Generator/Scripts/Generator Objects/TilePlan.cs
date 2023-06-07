using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class TilePlan
    {
        [SerializeField] private string code;

        public TilePlan(LevelPlan levelPlan, Vector3Int coordinates)
        {
            Level = levelPlan;
            Coordinates = coordinates;
            SectorsIds = new();
            ObstacleId = -1;
            Type = TileTypeNew.AREA;
            Overlap = TileOverlap.NONE;
        }

        public LevelPlan Level { get; }
        public Vector3Int Coordinates { get; }
        public HashSet<int> SectorsIds { get; }

        public int ObstacleId { get; set; }
        public TileTypeNew Type { get; set; }
        public TileOverlap Overlap { get; set; }
        public string Code
        {
            get
            {
                if (!string.IsNullOrEmpty(code))
                {
                    return code;
                }
                else if (Overlap != TileOverlap.NONE)
                {
                    return Overlap.ToString();
                }
                else
                {
                    return Type.ToString();
                }
            }
            set => code = value;
        }
        public ZandomTile Result { get; set; }

        public override string ToString()
        {
            return $"TilePlan {Coordinates} \'{Type}\' {Code}";
        }

        public bool HasObstacle()
        {
            return ObstacleId >= 0;
        }
    }
}
