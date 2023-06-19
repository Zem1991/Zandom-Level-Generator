using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class TileCodeReplacer
    {
        public TileCodeReplacer(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public void ReplaceArea(SectorPlan sectorPlan, string code)
        {
            IEnumerable<Vector3Int> coordinates = sectorPlan.TilesIds;
            ReplaceArea(coordinates, code);
        }

        public void ReplaceArea(IEnumerable<Vector3Int> coordinates, string code)
        {
            foreach (var item in coordinates)
            {
                LevelPlan.Tiles.TryGetValue(item, out TilePlan tile);
                if (tile.Type != TileType.AREA) continue;
                tile.Code = code;
            }
        }
    }
}
