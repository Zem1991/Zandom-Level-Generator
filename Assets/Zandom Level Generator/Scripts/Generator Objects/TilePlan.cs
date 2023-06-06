using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class TilePlan
    {
        //[Header("TilePlan")]
        //[SerializeField] private TileTypeNew type;
        //[SerializeField] private string code;

        public TilePlan(LevelPlan levelPlan, Vector3Int coordinates)
        {
            Level = levelPlan;
            Coordinates = coordinates;
            SectorsIds = new();
            ObstacleId = -1;
            Type = TileTypeNew.AREA;
            Code = Type.ToString();
        }

        public LevelPlan Level { get; }
        public Vector3Int Coordinates { get; }
        public HashSet<int> SectorsIds { get; }

        public int ObstacleId { get; set; }
        public TileTypeNew Type { get; set; }
        //public TileTypeNew Type
        //{
        //    get => type;
        //    set
        //    {
        //        type = value;
        //        RefreshTypeCode();
        //    }
        //}
        public string Code { get; set; }
        //public string Code
        //{
        //    get => code;
        //    set
        //    {
        //        code = value;
        //        RefreshTypeCode();
        //    }
        //}
        public ZandomTile Result { get; set; }

        public override string ToString()
        {
            return $"TilePlan {Coordinates} \'{Type}\' {Code}";
        }

        public bool HasObstacle()
        {
            return ObstacleId >= 0;
        }

        //private void RefreshTypeCode()
        //{
        //    if (string.IsNullOrEmpty(Code))
        //    {
        //        Code = Type.ToString();
        //    }
        //}
    }
}
