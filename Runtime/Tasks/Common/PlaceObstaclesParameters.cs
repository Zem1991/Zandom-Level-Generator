using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tasks.Common
{
    public struct PlaceObstaclesParameters
    {
        public PlaceObstaclesParameters(
            //string objectName, 
            Func<ZandomLevelGenerator, int> amountFunction,
            Func<ZandomLevelGenerator, TilePlan, bool> paddingTileFunction,
            Func<ZandomLevelGenerator, TilePlan, bool> obstacleTileFunction)
        {
            //ObjectName = objectName;
            AmountFunction = amountFunction;
            PaddingTileFunction = paddingTileFunction;
            ObstacleTileFunction = obstacleTileFunction;
        }
        
        //public string ObjectName { get; }
        public Func<ZandomLevelGenerator, int> AmountFunction { get; }
        public Func<ZandomLevelGenerator, TilePlan, bool> PaddingTileFunction { get; }
        public Func<ZandomLevelGenerator, TilePlan, bool> ObstacleTileFunction { get; }
    }
}
