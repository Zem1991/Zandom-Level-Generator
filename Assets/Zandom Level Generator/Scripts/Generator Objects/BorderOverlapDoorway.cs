using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class BorderOverlapDoorway
    {
        public BorderOverlapDoorway(LevelPlan levelPlan, int id, int wallId, HashSet<Vector3Int> tilesIds)
        {
            LevelPlan = levelPlan;
            Id = id;
            WallId = wallId;
            TilesIds = tilesIds;
        }

        public LevelPlan LevelPlan { get; }
        public int Id { get; }
        public int WallId { get; }
        public HashSet<Vector3Int> TilesIds { get; }
    }
}
