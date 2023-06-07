using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class SectorOverlap
    {
        public SectorOverlap(int sourceId, int otherId, HashSet<Vector3Int> tilesIds)
        {
            Id = new(sourceId, otherId);
            SourceId = sourceId;
            OtherId = otherId;
            TilesIds = tilesIds;
        }

        public Vector2Int Id { get; }
        public int SourceId { get; }
        public int OtherId { get; }
        public HashSet<Vector3Int> TilesIds { get; }
    }
}
