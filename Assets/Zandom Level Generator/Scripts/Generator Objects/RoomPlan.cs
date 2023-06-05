using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Tools.Builders;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class RoomPlan : SectorPlan
    {
        public RoomPlan(LevelPlan levelPlan, int id, Vector3Int start, Vector3Int size, SectorPlan parent = null) : 
            base(levelPlan, id, new CoordinatesGetter().Get(start, size), parent)
        {
            Start = start;
            Size = size;
        }

        public Vector3Int Start { get; }
        public Vector3Int Size { get; }

        public override string ToString()
        {
            return $"RoomPlan #{Id} \'{Type}\' {Code}";
        }
    }
}
