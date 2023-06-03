using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tasks.Common
{
    public struct CreateBuddingRoomsParameters
    {
        public CreateBuddingRoomsParameters(
            Func<ZandomLevelGenerator, List<RoomPlan>> rootRoomsFunction, 
            Func<ZandomLevelGenerator, SectorPlan, Vector3Int> roomSizeFunction, 
            Func<ZandomLevelGenerator, SectorPlan, bool> roomVerticalFunction, 
            Func<ZandomLevelGenerator, SectorPlan, bool> retryFunction, 
            Func<ZandomLevelGenerator, SectorPlan, bool> taskStopFunction)
        {
            RootRoomsFunction = rootRoomsFunction;
            RoomSizeFunction = roomSizeFunction;
            RoomVerticalFunction = roomVerticalFunction;
            RetryFunction = retryFunction;
            TaskStopFunction = taskStopFunction;
        }

        public Func<ZandomLevelGenerator, List<RoomPlan>> RootRoomsFunction { get; }
        public Func<ZandomLevelGenerator, SectorPlan, Vector3Int> RoomSizeFunction { get; }
        public Func<ZandomLevelGenerator, SectorPlan, bool> RoomVerticalFunction { get; }
        public Func<ZandomLevelGenerator, SectorPlan, bool> RetryFunction { get; }
        public Func<ZandomLevelGenerator, SectorPlan, bool> TaskStopFunction { get; }
    }
}
