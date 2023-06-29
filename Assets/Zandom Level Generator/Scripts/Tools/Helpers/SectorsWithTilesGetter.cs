using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class SectorsWithTilesGetter
    {
        public Dictionary<SectorPlan, List<TilePlan>> Get(LevelPlan levelPlan)
        {
            Dictionary<SectorPlan, List<TilePlan>> result = new();
            IEnumerable<SectorPlan> sectors = levelPlan.Sectors.Values;
            foreach (var sector in sectors)
            {
                List<TilePlan> tiles = new();
                foreach (var item in sector.TilesIds)
                {
                    levelPlan.Tiles.TryGetValue(item, out TilePlan tile);
                    tiles.Add(tile);
                }
                result.Add(sector, tiles);
            }
            return result;
        }
    }
}
