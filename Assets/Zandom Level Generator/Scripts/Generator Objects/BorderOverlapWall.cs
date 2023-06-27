using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class BorderOverlapWall
    {
        public BorderOverlapWall(LevelPlan levelPlan, int id, int sourceId, int otherId, HashSet<Vector3Int> tilesIds)
        {
            LevelPlan = levelPlan;
            Id = id;
            SourceId = sourceId;
            OtherId = otherId;
            TilesIds = tilesIds;
            DoorwayId = -1;
        }

        public LevelPlan LevelPlan { get; }
        public int Id { get; }
        public int SourceId { get; }
        public int OtherId { get; }
        public HashSet<Vector3Int> TilesIds { get; }

        public int DoorwayId { get; set; }

        public bool HasDoorway()
        {
            return DoorwayId >= 0;
        }
    }
}
