using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Factories;

namespace ZandomLevelGenerator.Tools.Helpers
{
    public class ObstacleToTilesLinker
    {
        public ObstacleToTilesLinker(StyleParameters styleParameters, LevelPlan levelPlan)
        {
            StyleParameters = styleParameters;
            LevelPlan = levelPlan;
        }

        public StyleParameters StyleParameters { get; }
        public LevelPlan LevelPlan { get; }

        //public void LinkIds(int obstacleId, HashSet<Vector3Int> tilesIds)
        public void LinkIds(Obstacle obstacle)
        {
            int obstacleId = obstacle.Id;
            HashSet<Vector3Int> tilesIds = obstacle.TilesIds;
            new TilePlanFactory(StyleParameters, LevelPlan).TryCreate(tilesIds, out Dictionary<Vector3Int, TilePlan> tiles);
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
