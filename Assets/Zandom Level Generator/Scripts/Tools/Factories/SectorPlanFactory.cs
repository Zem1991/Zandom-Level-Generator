using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class SectorPlanFactory
    {
        public SectorPlanFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }
        
        public SectorPlan Create(int id, HashSet<Vector3Int> tilesIds, SectorPlan parent = null)
        {
            bool exists = LevelPlan.Sectors.TryGetValue(id, out SectorPlan result);
            if (!exists)
            {
                result = new(LevelPlan, id, tilesIds, parent);
                LevelPlan.Sectors.Add(id, result);
            }
            LinkSectorToTiles(result, tilesIds);
            return result;
        }
        
        public SectorPlan Create(int id, Vector3Int start, Vector3Int size, SectorPlan parent = null)
        {
            HashSet<Vector3Int> tilesIds = new();
            BoundsInt boundsInt = new(start, size);
            foreach (Vector3Int point in boundsInt.allPositionsWithin)
            {
                tilesIds.Add(point);
            }
            return Create(id, tilesIds, parent);
        }

        private void LinkSectorToTiles(SectorPlan sector, HashSet<Vector3Int> tilesIds)
        {
            Dictionary<Vector3Int, TilePlan> tiles = new TilePlanFactory(LevelPlan).Create(tilesIds);
            foreach (var item in tiles)
            {
                Vector3Int coord = item.Key;
                sector.TilesIds.Add(coord);
                TilePlan tile = item.Value;
                tile.SectorsIds.Add(sector.Id);
            }
        }
    }
}
