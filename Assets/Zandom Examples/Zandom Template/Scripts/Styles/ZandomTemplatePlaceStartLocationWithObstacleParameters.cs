using System;
using System.Collections;
using System.Collections.Generic;
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

        public Func<ZandomLevelGenerator.ZandomLevelGenerator, TilePlan, bool> ValidTilesFunction()
        {
            bool result(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator, TilePlan tile)
            {
                bool canPlaceObstacle = tile.Type == TileTypeNew.AREA;
                return canPlaceObstacle;
            }
            return result;
        }
    }
}
