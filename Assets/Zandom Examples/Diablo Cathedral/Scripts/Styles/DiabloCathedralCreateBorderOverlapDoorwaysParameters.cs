using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Examples.DiabloCathedral;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Common;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Styles
{
    public class DiabloCathedralCreateBorderOverlapDoorwaysParameters
    {
        public CreateBorderOverlapDoorwaysParameters CreateParameters()
        {
            var wallListFunction = WallListFunction();
            var doorwayLengthFunction = DoorwayLengthFunction();
            var doorwayPositionFunction = DoorwayPositionFunction();
            CreateBorderOverlapDoorwaysParameters result = new(wallListFunction, doorwayLengthFunction, doorwayPositionFunction);
            return result;
        }

        public Func<ZandomLevelGenerator, List<BorderOverlapWall>> WallListFunction()
        {
            List<BorderOverlapWall> result(ZandomLevelGenerator zandomLevelGenerator)
            {
                DiabloCathedralStyleParameters parameters = zandomLevelGenerator.ZandomParameters as DiabloCathedralStyleParameters;
                int minSize = parameters.SmallDoorwayLength;
                List<BorderOverlapWall> result = new();
                foreach (var item in zandomLevelGenerator.GeneratorCoroutine.Level.BorderOverlapWalls)
                {
                    BorderOverlapWall wall = item.Value;
                    if (wall.TilesIds.Count < minSize) continue;
                    zandomLevelGenerator.GeneratorCoroutine.Level.Sectors.TryGetValue(wall.SourceId, out SectorPlan source);
                    zandomLevelGenerator.GeneratorCoroutine.Level.Sectors.TryGetValue(wall.OtherId, out SectorPlan other);
                    bool isParent = other.Parent == source;
                    if (!isParent) continue;
                    result.Add(wall);
                }
                return result;
            }
            return result;
        }

        public Func<ZandomLevelGenerator, BorderOverlapWall, int> DoorwayLengthFunction()
        {
            int result(ZandomLevelGenerator zandomLevelGenerator, BorderOverlapWall wall)
            {
                DiabloCathedralStyleParameters parameters = zandomLevelGenerator.ZandomParameters as DiabloCathedralStyleParameters;
                int small = parameters.SmallDoorwayLength;
                int large = parameters.LargeDoorwayLength;
                int wallLength = wall.TilesIds.Count;
                if (wallLength < 2 * small) return small;
                if (wallLength >= 2 * large) return large;
                bool useLarge = zandomLevelGenerator.GeneratorCoroutine.SeededRandom.NextBool();
                return useLarge ? large : small;
            }
            return result;
        }

        public Func<ZandomLevelGenerator, BorderOverlapWall, int, Vector3Int> DoorwayPositionFunction()
        {
            Vector3Int result(ZandomLevelGenerator zandomLevelGenerator, BorderOverlapWall wall, int doorLength)
            {
                int available = wall.TilesIds.Count;
                available -= doorLength;
                available++;
                int index = zandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(0, available);
                Vector3Int result = wall.TilesIds.ElementAt(index);
                return result;
            }
            return result;
        }
    }
}
