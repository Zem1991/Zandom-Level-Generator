using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tasks.Common
{
    public struct PlaceDoorwayObstaclesParameters
    {
        public PlaceDoorwayObstaclesParameters(
            Func<ZandomLevelGenerator, string> objectNameFunction,
            Func<ZandomLevelGenerator, List<BorderOverlapDoorway>> doorwaysFunction)
        {
            ObjectNameFunction = objectNameFunction;
            DoorwaysFunction = doorwaysFunction;
        }

        public Func<ZandomLevelGenerator, string> ObjectNameFunction { get; }
        public Func<ZandomLevelGenerator, List<BorderOverlapDoorway>> DoorwaysFunction { get; }
    }
}
