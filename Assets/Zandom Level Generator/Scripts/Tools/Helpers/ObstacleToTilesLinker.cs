using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Factories;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class ObstacleToTilesLinker
    {
        public ObstacleToTilesLinker(LevelPlan levelPlan)
        {
            LevelPlan = levelPlan;
        }

        public LevelPlan LevelPlan { get; }

        //public void LinkIds(int obstacleId, HashSet<Vector3Int> tilesIds)
        public void LinkIds(Obstacle obstacle)
        {
            int obstacleId = obstacle.Id;
            HashSet<Vector3Int> tilesIds = obstacle.TilesIds;
            Dictionary<Vector3Int, TilePlan> tiles = new TilePlanFactory(LevelPlan).Create(tilesIds);
            foreach (var item in tiles)
            {
                Vector3Int coord = item.Key;
                obstacle.TilesIds.Add(coord);
                TilePlan tile = item.Value;
                tile.ObstacleId = obstacleId;
            }
        }
    }
}
