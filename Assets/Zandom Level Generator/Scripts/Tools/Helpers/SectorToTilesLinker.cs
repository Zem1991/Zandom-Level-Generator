using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Factories;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class SectorToTilesLinker
    {
        public SectorToTilesLinker(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public void Link(int sectorId, HashSet<Vector3Int> tilesIds)
        {
            LevelPlan.Sectors.TryGetValue(sectorId, out SectorPlan sector);
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
