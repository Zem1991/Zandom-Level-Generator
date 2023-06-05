using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class Obstacle
    {
        public Obstacle(LevelPlan levelPlan, int id, HashSet<Vector3Int> tilesIds, ObstacleData data)
        {
            LevelPlan = levelPlan;
            Id = id;
            TilesIds = tilesIds;
            Data = data;
            Position = new PositionGetter().GetCenter(tilesIds);
            PointOfInterestId = -1;
        }

        public LevelPlan LevelPlan { get; }
        public int Id { get; }
        public HashSet<Vector3Int> TilesIds { get; }
        public ObstacleData Data { get; }
        public Vector3 Position { get; }

        public int PointOfInterestId { get; set; }

        public override string ToString()
        {
            return $"Obstacle #{Id} \'{Data.GameObject.name}\'";
        }

        public bool HasPointOfInterest()
        {
            return PointOfInterestId >= 0;
        }
    }
}
