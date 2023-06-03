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
            Func<ZandomLevelGenerator, List<TilePlan>> validTilesFunction)
        {
            //ObjectName = objectName;
            AmountFunction = amountFunction;
            ValidTilesFunction = validTilesFunction;
        }
        
        //public string ObjectName { get; }
        public Func<ZandomLevelGenerator, int> AmountFunction { get; }
        public Func<ZandomLevelGenerator, List<TilePlan>> ValidTilesFunction { get; }
    }
}
