using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Samples.DiabloCathedral.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Common;

namespace ZandomLevelGenerator.Samples.DiabloCathedral.Styles
{
    public class DiabloCathedralCreateBuddingRoomsParameters
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
                List<SectorPlan> sectorPlans = zandomLevelGenerator.GeneratorCoroutine.Level.Sectors.Values.Take(2).ToList();
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
                int PickInt()
                {
                    int size = zandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(3, 6);
                    size *= 2;      //Mirrored for {6, 8, 10} sizes
                    size += 2;      //+2 for each Border on each orientation
                    return size;
                }
                Vector3Int PickVector2Int()
                {
                    int sizeX = PickInt();
                    int sizeZ = PickInt();
                    return new(sizeX, 1, sizeZ);
                }
                return PickVector2Int();
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
                SectorPlan parent = sectorPlan.Parent;
                if (parent == null) return true;
                SectorPlan grandparent = parent.Parent;
                if (grandparent == null) return true;
                return sectorPlan.Vertical != parent.Vertical;
            }
            return result;
        }

        public Func<ZandomLevelGenerator, SectorPlan, bool> TaskStopFunction()
        {
            bool result(ZandomLevelGenerator zandomLevelGenerator, SectorPlan sectorPlan)
            {
                LevelPlan level = zandomLevelGenerator.GeneratorCoroutine.Level;
                Dictionary<int, SectorPlan> sectors = level.Sectors;
                DiabloCathedralStyleParameters zandomTemplateStyleParameters = zandomLevelGenerator.ZandomParameters as DiabloCathedralStyleParameters;
                int currentArea = level.Tiles.Count;
                int levelArea = zandomTemplateStyleParameters.Area;
                float fillTarget = zandomTemplateStyleParameters.AreaFillTarget;
                int targetArea = Mathf.RoundToInt(levelArea * fillTarget);
                bool stop = currentArea >= targetArea;
                return stop;
            }
            return result;
        }
    }
}
