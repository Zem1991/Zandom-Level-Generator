using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Common;

namespace ZandomTemplate.Styles
{
    public class ZandomTemplatePlaceStartLocationWithObstacleParameters
    {
        public PlaceObstaclesParameters CreateParameters()
        {
            var amountFunction = AmountFunction();
            var validTilesFunction = ValidTilesFunction();
            PlaceObstaclesParameters result = new(amountFunction, validTilesFunction);
            return result;
        }

        public Func<ZandomLevelGenerator.ZandomLevelGenerator, int> AmountFunction()
        {
            int result(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator)
            {
                return 1;
            }
            return result;
        }

        public Func<ZandomLevelGenerator.ZandomLevelGenerator, List<TilePlan>> ValidTilesFunction()
        {
            List<TilePlan> result(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator)
            {
                List<TilePlan> tiles = new();
                foreach (var item in zandomLevelGenerator.GeneratorCoroutine.Level.Tiles.Values)
                {
                    bool canPlaceObstacle = item.Type == TileTypeNew.AREA;
                    if (!canPlaceObstacle) continue;
                    tiles.Add(item);
                }
                tiles = tiles.OrderBy(x => zandomLevelGenerator.GeneratorCoroutine.SeededRandom.Next()).ToList();
                return tiles;
            }
            return result;
        }
    }
}
