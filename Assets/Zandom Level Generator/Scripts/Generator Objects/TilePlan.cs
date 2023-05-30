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
            Obstacle = null;
            Sectors = new();
        }

        public LevelPlan Level { get; }
        public Vector3Int Coordinates { get; }

        public TileTypeNew Type { get; set; }
        public string Code { get; set; }
        public TileResult Result { get; set; }
        public Obstacle Obstacle { get; set; }

        public Dictionary<int, SectorPlan> Sectors { get; }

        public override string ToString()
        {
            return $"TilePlan {Coordinates} \'{Type}\' {Code}";
        }

        //public bool TryGetSector(int id, out SectorPlan sector)
        //{
        //    return Sectors.TryGetValue(id, out sector);
        //}

        //public void AddSector(SectorPlan sector)
        //{
        //    Sectors.Add(sector.Id, sector);
        //}
    }
}
