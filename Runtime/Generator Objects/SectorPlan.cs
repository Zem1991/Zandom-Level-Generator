using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.ResultObjects;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class SectorPlan
    {
        public SectorPlan(LevelPlan levelPlan, int id, HashSet<Vector3Int> tilesIds, bool vertical, SectorPlan parent = null)
        {
            Level = levelPlan;
            Id = id;
            TilesIds = new(tilesIds);
            Vertical = vertical;
            Parent = parent;
            GenerationAge = parent?.GenerationAge + 1 ?? 0;
            ChildrenIds = new();
        }

        public LevelPlan Level { get; }
        public int Id { get; }
        public HashSet<Vector3Int> TilesIds { get; }
        public bool Vertical { get; }
        public SectorPlan Parent { get; }
        public int GenerationAge { get; }
        public HashSet<int> ChildrenIds { get; }

        public SectorType Type { get; set; }
        public string Code { get; set; }
        public ZandomSector Result { get; set; }

        public override string ToString()
        {
            return $"SectorPlan #{Id} \'{Type}\' {Code}";
        }
    }
}
