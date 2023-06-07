using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Builders;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class BorderOverlapDoorwayFactory
    {
        public BorderOverlapDoorwayFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

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
            return result;
        }
    }
}
