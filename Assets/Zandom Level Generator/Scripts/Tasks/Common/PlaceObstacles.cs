using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Checkers;
using ZandomLevelGenerator.Tools.Factories;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tasks.Common
{
    public class PlaceObstacles : GeneratorTask
    {
        public PlaceObstacles(ZandomLevelGenerator zandomLevelGenerator, string objectName, PlaceObstaclesParameters parameters) : base(zandomLevelGenerator)
        {
            ObjectName = objectName;
            Parameters = parameters;
            NewObstacles = new();
        }

        public string ObjectName { get; }
        public PlaceObstaclesParameters Parameters { get; }
        public Dictionary<int, Obstacle> NewObstacles { get; }

        protected override void RunContents()
        {
            ObstacleData data = ZandomLevelGenerator.ZandomObstacleList.Get(ObjectName);
            int amount = Parameters.AmountFunction(ZandomLevelGenerator);
            List<TilePlan> validTiles = Parameters.ValidTilesFunction(ZandomLevelGenerator);
            Queue<TilePlan> validTilesQueue = new(validTiles);
            //while (!Parameters.TaskStopFunction(ZandomLevelGenerator, current) && NewRooms.Count > 0)
            while (NewObstacles.Count < amount && validTilesQueue.Count > 0)
            {
                TilePlan tile = validTilesQueue.Dequeue();
                bool canUseTile = TryTile(data, tile, out HashSet<Vector3Int> coordinates);
                if (!canUseTile) continue;
                ObstacleFactory factory = new(ZandomLevelGenerator.GeneratorCoroutine.Level);
                int obstacleId = factory.NextId();
                Obstacle obstacle = factory.Create(obstacleId, coordinates, data);
                NewObstacles.Add(obstacleId, obstacle);
            }
        }

        private bool TryTile(ObstacleData data, TilePlan tile, out HashSet<Vector3Int> coordinates)
        {
            Vector3Int start = tile.Coordinates;
            Vector3Int size = data.Size;
            Vector3Int padding = data.Padding;
            //int extraX = LevelGenerator.SeededRandom.Range(padding.x, room.Size.x - size.x - padding.x + 1);
            //int extraY = LevelGenerator.SeededRandom.Range(padding.y, room.Size.y - size.y - padding.y + 1);
            //position.x += extraX;
            //position.y += extraY;
            coordinates = new CoordinatesGetter().Get(start, size);
            bool canBuild = new AreaAvailabilityChecker(ZandomLevelGenerator.GeneratorCoroutine.Level).IsAvailableForObstacle(coordinates);
            return canBuild;
        }
    }
}
