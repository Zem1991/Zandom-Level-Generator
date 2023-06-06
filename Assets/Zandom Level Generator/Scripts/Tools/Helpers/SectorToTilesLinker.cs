using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.ResultObjects;
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

        //public void LinkIds(int sectorId, HashSet<Vector3Int> tilesIds)
        public void LinkIds(SectorPlan sector)
        {
            int sectorId = sector.Id;
            HashSet<Vector3Int> tilesIds = sector.TilesIds;
            Dictionary<Vector3Int, TilePlan> tiles = new TilePlanFactory(LevelPlan).Create(tilesIds);
            foreach (var item in tiles)
            {
                Vector3Int coord = item.Key;
                sector.TilesIds.Add(coord);
                TilePlan tile = item.Value;
                tile.SectorsIds.Add(sectorId);
            }
        }

        public void LinkTransforms(ZandomSector sector)
        {
            Transform parent = sector.transform;
            Dictionary<Vector3Int, TilePlan> tiles = new TilePlanFactory(LevelPlan).Create(sector.SectorPlan.TilesIds);
            foreach (var item in tiles)
            {
                Transform child = item.Value.Result.transform;
                child.parent = parent;
            }
        }
    }
}
