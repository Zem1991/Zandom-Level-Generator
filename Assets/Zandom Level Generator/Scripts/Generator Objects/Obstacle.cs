using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.ResultObjects;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.GeneratorObjects
{
    public class Obstacle
    {
        public Obstacle(LevelPlan levelPlan, int id, HashSet<Vector3Int> tilesIds, Vector3 rotationEuler, ObstacleData data)
        {
            LevelPlan = levelPlan;
            Id = id;
            TilesIds = tilesIds;
            RotationEuler = rotationEuler;
            Data = data;
            Position = new PositionGetter().GetCenter(tilesIds);
            PointOfInterestId = -1;
        }

        public LevelPlan LevelPlan { get; }
        public int Id { get; }
        public HashSet<Vector3Int> TilesIds { get; }
        public Vector3 RotationEuler { get; }
        public ObstacleData Data { get; }
        public Vector3 Position { get; }

        public int PointOfInterestId { get; set; }
        public ZandomObstacle Result { get; set; }

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
