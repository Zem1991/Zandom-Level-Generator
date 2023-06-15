using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using ZandomLevelGenerator;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Common;
using ZandomLevelGenerator.Examples.ZandomTemplate.Customizables;

namespace ZandomLevelGenerator.Examples.ZandomTemplate.Styles
{
    public class ZandomTemplateCreateBuddingRoomsParameters
    {
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

        public Func<ZandomLevelGenerator, List<RoomPlan>> RootRoomsFunction()
        {
            List<RoomPlan> result(ZandomLevelGenerator zandomLevelGenerator)
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

        public Func<ZandomLevelGenerator, SectorPlan, Vector3Int> RoomSizeFunction()
        {
            Vector3Int result(ZandomLevelGenerator zandomLevelGenerator, SectorPlan sectorPlan)
            {
                ZandomTemplateStyleParameters zandomTemplateStyleParameters = zandomLevelGenerator.ZandomParameters as ZandomTemplateStyleParameters;
                Vector3Int result = zandomTemplateStyleParameters.BuddingRoomSize;
                return result;
            }
            return result;
        }

        public Func<ZandomLevelGenerator, SectorPlan, bool> RoomVerticalFunction()
        {
            bool result(ZandomLevelGenerator zandomLevelGenerator, SectorPlan parent)
            {
                bool result;
                bool enoughParents = parent?.Parent != null;
                if (enoughParents)
                {
                    bool parentsWithSameOrientation = parent.Vertical == parent.Parent.Vertical;
                    if (parentsWithSameOrientation)
                    {
                        result = !parent.Vertical;
                    }
                    else
                    {
                        bool keepSame = zandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(0, 4) <= 0;
                        if (keepSame) result = parent.Vertical;
                        else result = !parent.Vertical;
                    }
                }
                else
                {
                    result = !parent.Vertical;
                }
                return result;
            }
            return result;
        }

        public Func<ZandomLevelGenerator, SectorPlan, bool> RetryFunction()
        {
            bool result(ZandomLevelGenerator zandomLevelGenerator, SectorPlan sectorPlan)
            {
                return false;
            }
            return result;
        }

        public Func<ZandomLevelGenerator, SectorPlan, bool> TaskStopFunction()
        {
            bool result(ZandomLevelGenerator zandomLevelGenerator, SectorPlan sectorPlan)
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
