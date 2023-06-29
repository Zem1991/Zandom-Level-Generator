using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Common;

namespace ZandomLevelGenerator.Examples.ZandomTemplate.Styles
{
    public class ZandomTemplatePlaceStartLocationWithObstacleParameters
    {
        public PlaceObstaclesParameters CreateParameters()
        {
            var amountFunction = AmountFunction();
            var paddingTileFunction = PaddingTileFunction();
            var obstacleTileFunction = ObstacleTileFunction();
            PlaceObstaclesParameters result = new(amountFunction, paddingTileFunction, obstacleTileFunction);
            return result;
        }

        public Func<ZandomLevelGenerator, int> AmountFunction()
        {
            int result(ZandomLevelGenerator zandomLevelGenerator)
            {
                return 1;
            }
            return result;
        }

        public Func<ZandomLevelGenerator, TilePlan, bool> PaddingTileFunction()
        {
            bool result(ZandomLevelGenerator zandomLevelGenerator, TilePlan tile)
            {
                return true;
            }
            return result;
        }

        public Func<ZandomLevelGenerator, TilePlan, bool> ObstacleTileFunction()
        {
            bool result(ZandomLevelGenerator zandomLevelGenerator, TilePlan tile)
            {
                bool canPlaceObstacle = tile.Type == TileType.AREA;
                return canPlaceObstacle;
            }
            return result;
        }
    }
}
