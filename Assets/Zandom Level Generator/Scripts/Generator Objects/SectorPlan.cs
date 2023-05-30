using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class SectorPlan
    {
        public SectorPlan(LevelPlan levelPlan, int id, SectorPlan parent = null)
        {
            Level = levelPlan;
            Id = id;
            Parent = parent;
            Children = new();
            Tiles = new();
        }

        public LevelPlan Level { get; }
        public int Id { get; }
        public SectorPlan Parent { get; }

        public SectorType Type { get; set; }
        public string Code { get; set; }
        public SectorResult Result { get; set; }

        public Dictionary<int, SectorPlan> Children { get; }
        public Dictionary<Vector3Int, TilePlan> Tiles { get; }

        public override string ToString()
        {
            return $"SectorPlan #{Id} \'{Type}\' {Code}";
        }

        //public bool TryGetTile(Vector3Int coordinates, out TilePlan tile)
        //{
        //    return Tiles.TryGetValue(coordinates, out tile);
        //}

        //public void AddTile(TilePlan tile)
        //{
        //    Tiles.Add(tile.Coordinates, tile);
        //}
    }
}
