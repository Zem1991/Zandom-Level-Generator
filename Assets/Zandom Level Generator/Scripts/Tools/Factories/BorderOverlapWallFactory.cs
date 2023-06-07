using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Builders;

namespace ZandomLevelGenerator.Tools.Factories
{
    public class BorderOverlapWallFactory
    {
        public BorderOverlapWallFactory(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        public int NextId()
        {
            return LevelPlan.BorderOverlapWalls.Count;
        }

        public BorderOverlapWall Create(int id, int sourceId, int otherId, HashSet<Vector3Int> tilesIds)
        {
            bool exists = LevelPlan.BorderOverlapWalls.TryGetValue(id, out BorderOverlapWall result);
            if (!exists)
            {
                result = new(LevelPlan, id, sourceId, otherId, tilesIds);
                LevelPlan.BorderOverlapWalls.Add(id, result);
            }
            new WallTileBuilder(result).FillWall();
            return result;
        }
    }
}
