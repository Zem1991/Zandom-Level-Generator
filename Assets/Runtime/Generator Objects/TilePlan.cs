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
            Type = TileType.AREA;
            Overlap = TileOverlap.NONE;
        }

        public LevelPlan Level { get; }
        public Vector3Int Coordinates { get; }
        public HashSet<int> SectorsIds { get; }

        public int ObstacleId { get; set; }
        public TileType Type { get; set; }
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
            //set => code = value;
            set
            {
                code = null;
                if (value == TileType.AREA.ToString()) Type = TileType.AREA;
                else if (value == TileType.BORDER.ToString()) Type = TileType.BORDER;
                else if (value == TileType.CORNER.ToString()) Type = TileType.CORNER;
                else if (value == TileOverlap.WALL.ToString()) Overlap = TileOverlap.WALL;
                else if (value == TileOverlap.DOORWAY.ToString()) Overlap = TileOverlap.DOORWAY;
                else code = value;
            }
            //set
            //{
            //    code = null;
            //    if (value == TileType.AREA.ToString())
            //    {
            //        Type = TileType.AREA;
            //        Overlap = TileOverlap.NONE;
            //    }
            //    else if (value == TileType.BORDER.ToString())
            //    {
            //        Type = TileType.BORDER;
            //        Overlap = TileOverlap.NONE;
            //    }
            //    else if (value == TileType.CORNER.ToString())
            //    {
            //        Type = TileType.CORNER;
            //        Overlap = TileOverlap.NONE;
            //    }
            //    else if (value == TileOverlap.WALL.ToString())
            //    {
            //        Overlap = TileOverlap.WALL;
            //    }
            //    else if (value == TileOverlap.DOORWAY.ToString())
            //    {
            //        Overlap = TileOverlap.DOORWAY;
            //    }
            //    else code = value;
            //}
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
