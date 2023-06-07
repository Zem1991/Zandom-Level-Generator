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
            Func<ZandomLevelGenerator, TilePlan, bool> validTileFunction)
        {
            //ObjectName = objectName;
            AmountFunction = amountFunction;
            ValidTileFunction = validTileFunction;
        }
        
        //public string ObjectName { get; }
        public Func<ZandomLevelGenerator, int> AmountFunction { get; }
        public Func<ZandomLevelGenerator, TilePlan, bool> ValidTileFunction { get; }
    }
}
