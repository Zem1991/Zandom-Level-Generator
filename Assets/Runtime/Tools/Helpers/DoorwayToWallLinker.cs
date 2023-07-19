using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class DoorwayToWallLinker
    {
        public DoorwayToWallLinker(StyleParameters zandomParameters, LevelPlan levelPlan)
        {
            ZandomParameters = zandomParameters;
            LevelPlan = levelPlan;
        }

        public StyleParameters ZandomParameters { get; }
        public LevelPlan LevelPlan { get; }

        public void LinkIds(BorderOverlapDoorway doorway)
        {
            int doorwayId = doorway.Id;
            int wallId = doorway.WallId;
            LevelPlan.BorderOverlapWalls.TryGetValue(wallId, out BorderOverlapWall wall);
            wall.DoorwayId = doorwayId;
        }
    }
}
