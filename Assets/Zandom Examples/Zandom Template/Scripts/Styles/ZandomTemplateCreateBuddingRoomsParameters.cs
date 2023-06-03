using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Common;
using ZandomTemplate.Customizables;

namespace ZandomTemplate.Styles
{
    public class ZandomTemplateCreateBuddingRoomsParameters
    {
        public ZandomTemplateCreateBuddingRoomsParameters(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator)
        {
            ZandomLevelGenerator = zandomLevelGenerator;
        }

        public ZandomLevelGenerator.ZandomLevelGenerator ZandomLevelGenerator { get; }
        
        public CreateBuddingRoomsParameters CreateParameters()
        {
            var rootRoomsFunction = RootRoomsFunction();
            var roomSizeFunction = RoomSizeFunction();
            var roomVerticalFunction = RoomVerticalFunction();
            var retryFunction = RetryFunction();
            var taskStopFunction = TaskStopFunction();
            CreateBuddingRoomsParameters result = new(rootRoomsFunction, roomSizeFunction, roomVerticalFunction, retryFunction, taskStopFunction);
            return result;
        }

        public Func<ZandomLevelGenerator.ZandomLevelGenerator, List<RoomPlan>> RootRoomsFunction()
        {
            List<RoomPlan> result(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator)
            {
                List<SectorPlan> sectorPlans = zandomLevelGenerator.GeneratorCoroutine.Level.Sectors.Values.Take(1).ToList();
                List<RoomPlan> result = new();
                foreach (var item in sectorPlans)
                {
                    RoomPlan room = item as RoomPlan;
                    if (room == null) continue;
                    result.Add(room);
                }
                return result;
            }
            return result;
        }

        public Func<ZandomLevelGenerator.ZandomLevelGenerator, SectorPlan, Vector3Int> RoomSizeFunction()
        {
            Vector3Int result(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator, SectorPlan sectorPlan)
            {
                ZandomTemplateStyleParameters zandomTemplateStyleParameters = zandomLevelGenerator.ZandomParameters as ZandomTemplateStyleParameters;
                Vector3Int result = zandomTemplateStyleParameters.BuddingRoomSize;
                return result;
            }
            return result;
        }

        public Func<ZandomLevelGenerator.ZandomLevelGenerator, SectorPlan, bool> RoomVerticalFunction()
        {
            bool result(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator, SectorPlan sectorPlan)
            {
                return false;
            }
            return result;
        }

        public Func<ZandomLevelGenerator.ZandomLevelGenerator, SectorPlan, bool> RetryFunction()
        {
            bool result(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator, SectorPlan sectorPlan)
            {
                return false;
            }
            return result;
        }

        public Func<ZandomLevelGenerator.ZandomLevelGenerator, SectorPlan, bool> TaskStopFunction()
        {
            bool result(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator, SectorPlan sectorPlan)
            {
                Dictionary<int, SectorPlan> sectors = zandomLevelGenerator.GeneratorCoroutine.Level.Sectors;
                ZandomTemplateStyleParameters zandomTemplateStyleParameters = zandomLevelGenerator.ZandomParameters as ZandomTemplateStyleParameters;
                int sectorCountTarget = zandomTemplateStyleParameters.SectorCountTarget;
                bool stop = sectors.Count >= sectorCountTarget;
                return stop;
            }
            return result;
        }
    }
}
