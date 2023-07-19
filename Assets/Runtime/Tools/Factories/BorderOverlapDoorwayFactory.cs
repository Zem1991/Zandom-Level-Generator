using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Builders;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class BorderOverlapDoorwayFactory
    {
        public BorderOverlapDoorwayFactory(StyleParameters styleParameters, LevelPlan levelPlan)
        {
            StyleParameters = styleParameters;
            LevelPlan = levelPlan;
        }

        public StyleParameters StyleParameters { get; }
        public LevelPlan LevelPlan { get; }

        public int NextId()
        {
            return LevelPlan.BorderOverlapDoorways.Count;
        }

        public BorderOverlapDoorway Create(int id, int wallId, HashSet<Vector3Int> tilesIds)
        {
            bool exists = LevelPlan.BorderOverlapDoorways.TryGetValue(id, out BorderOverlapDoorway result);
            if (!exists)
            {
                result = new(LevelPlan, id, wallId, tilesIds);
                LevelPlan.BorderOverlapDoorways.Add(id, result);
            }
            new DoorwayTileBuilder(result).FillDoorway();
            new DoorwayToWallLinker(StyleParameters, LevelPlan).LinkIds(result);
            return result;
        }
    }
}
