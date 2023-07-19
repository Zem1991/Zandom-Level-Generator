using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tasks.Common
{
    public struct CreateBorderOverlapDoorwaysParameters
    {
        public CreateBorderOverlapDoorwaysParameters(
            Func<ZandomLevelGenerator, List<BorderOverlapWall>> wallListFunction,
            Func<ZandomLevelGenerator, BorderOverlapWall, int> doorwayLengthFunction, 
            Func<ZandomLevelGenerator, BorderOverlapWall, int, Vector3Int> doorwayPositionFunction)
        {
            WallListFunction = wallListFunction;
            DoorwayLengthFunction = doorwayLengthFunction;
            DoorwayPositionFunction = doorwayPositionFunction;
        }

        public Func<ZandomLevelGenerator, List<BorderOverlapWall>> WallListFunction { get; }
        public Func<ZandomLevelGenerator, BorderOverlapWall, int> DoorwayLengthFunction { get; }
        public Func<ZandomLevelGenerator, BorderOverlapWall, int, Vector3Int> DoorwayPositionFunction { get; }
    }
}
