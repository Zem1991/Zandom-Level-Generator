using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tasks.Common;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Styles
{
    public class DiabloCathedralPlaceSmallDoorParameters
    {
        public PlaceDoorwayObstaclesParameters CreateParameters()
        {
            var objectNameFunction = ObjectNameFunction();
            var doorwaysFunction = DoorwaysFunction();
            PlaceDoorwayObstaclesParameters result = new(objectNameFunction, doorwaysFunction);
            return result;
        }

        public Func<ZandomLevelGenerator, string> ObjectNameFunction()
        {
            string result(ZandomLevelGenerator zandomLevelGenerator)
            {
                return "Small Door";
            }
            return result;
        }

        public Func<ZandomLevelGenerator, List<BorderOverlapDoorway>> DoorwaysFunction()
        {
            List<BorderOverlapDoorway> result(ZandomLevelGenerator zandomLevelGenerator)
            {
                List<BorderOverlapDoorway> result = new();
                LevelPlan levelPlan = zandomLevelGenerator.GeneratorCoroutine.Level;
                foreach (var item in levelPlan.BorderOverlapDoorways)
                {
                    BorderOverlapDoorway doorway = item.Value;
                    if (doorway.TilesIds.Count != 2) continue;
                    levelPlan.BorderOverlapWalls.TryGetValue(doorway.WallId, out BorderOverlapWall wall);
                    if (wall.TileCode == "Area") continue;
                    result.Add(doorway);
                }
                return result;
            }
            return result;
        }
    }
}
