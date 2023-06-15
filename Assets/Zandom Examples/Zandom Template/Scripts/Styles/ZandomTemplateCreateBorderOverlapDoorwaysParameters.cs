using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Common;
using ZandomLevelGenerator.Examples.ZandomTemplate.Customizables;

namespace ZandomLevelGenerator.Examples.ZandomTemplate.Styles
{
    public class ZandomTemplateCreateBorderOverlapDoorwaysParameters
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
                ZandomTemplateStyleParameters parameters = zandomLevelGenerator.ZandomParameters as ZandomTemplateStyleParameters;
                int minSize = parameters.DoorwayLength;
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
                ZandomTemplateStyleParameters parameters = zandomLevelGenerator.ZandomParameters as ZandomTemplateStyleParameters;
                return parameters.DoorwayLength;
            }
            return result;
        }

        public Func<ZandomLevelGenerator, BorderOverlapWall, int, Vector3Int> DoorwayPositionFunction()
        {
            Vector3Int result(ZandomLevelGenerator zandomLevelGenerator, BorderOverlapWall wall, int length)
            {
                int count = wall.TilesIds.Count;
                count /= 2;             //Central position
                //count -= 1;             //Zero-based numbering
                count -= length / 2;    //Half doorway length
                Vector3Int result = wall.TilesIds.ElementAt(count);
                return result;
            }
            return result;
        }
    }
}
