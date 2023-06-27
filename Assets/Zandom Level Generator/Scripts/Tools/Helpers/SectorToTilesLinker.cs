using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.ResultObjects;
using ZandomLevelGenerator.Tools.Factories;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class SectorToTilesLinker
    {
        public SectorToTilesLinker(StyleParameters zandomParameters, LevelPlan levelPlan)
        {
            ZandomParameters = zandomParameters;
            LevelPlan = levelPlan;
        }

        public StyleParameters ZandomParameters { get; }
        public LevelPlan LevelPlan { get; }

        //public void LinkIds(int sectorId, HashSet<Vector3Int> tilesIds)
        public void LinkIds(SectorPlan sector)
        {
            int sectorId = sector.Id;
            HashSet<Vector3Int> tilesIds = sector.TilesIds;
            new TilePlanFactory(ZandomParameters, LevelPlan).TryCreate(tilesIds, out Dictionary<Vector3Int, TilePlan> tiles);
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
            new TilePlanFactory(ZandomParameters, LevelPlan).TryCreate(sector.SectorPlan.TilesIds, out Dictionary<Vector3Int, TilePlan> tiles);
            foreach (var item in tiles)
            {
                Transform child = item.Value.Result.transform;
                child.parent = parent;
            }
        }
    }
}
