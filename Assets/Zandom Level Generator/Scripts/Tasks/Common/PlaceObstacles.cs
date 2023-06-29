using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
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

        public override void RunContents()
        {
            string name = ObjectName;
            ObstacleData data = ZandomLevelGenerator.ZandomObstacleList.Get(name);
            int amount = Parameters.AmountFunction(ZandomLevelGenerator);
            List<TilePlan> startTiles = FindStartTiles();
            Queue<TilePlan> startTilesQueue = new(startTiles);
            //while (!Parameters.TaskStopFunction(ZandomLevelGenerator, current) && NewRooms.Count > 0)
            while (NewObstacles.Count < amount && startTilesQueue.Count > 0)
            {
                TilePlan startTile = startTilesQueue.Dequeue();
                bool canUseTile = TryStartTile(startTile, data, out HashSet <Vector3Int> coordinates);
                if (!canUseTile) continue;
                ObstacleFactory factory = new(ZandomLevelGenerator.ZandomParameters, ZandomLevelGenerator.GeneratorCoroutine.Level);
                int obstacleId = factory.NextId();
                //TODO: make padding tiles only pad and not actually register an obstacle over them
                Obstacle obstacle = factory.Create(obstacleId, coordinates, Vector3.zero, data);
                NewObstacles.Add(obstacleId, obstacle);
            }
        }

        private List<TilePlan> FindStartTiles()
        {
            List<TilePlan> tiles = new();
            foreach (var item in ZandomLevelGenerator.GeneratorCoroutine.Level.Tiles.Values)
            {
                bool checkOk = PaddingCheck(item);
                if (!checkOk) continue;
                tiles.Add(item);
            }
            tiles = tiles.OrderBy(x => ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Next()).ToList();
            return tiles;
        }

        private bool TryStartTile(TilePlan startTile, ObstacleData data, out HashSet<Vector3Int> obstacleCoordinates)
        {
            Vector3Int obstacleStart = startTile.Coordinates;
            Vector3Int obstacleSize = data.Size;
            obstacleCoordinates = new CoordinatesGetter().Get(obstacleStart, obstacleSize);
            Vector3Int paddingSize = data.Padding;
            Vector3Int paddingStart = obstacleStart - paddingSize;
            paddingSize *= 2;
            paddingSize += obstacleSize;
            paddingSize.y = 1;
            HashSet<Vector3Int> paddingCoordinates = new CoordinatesGetter().Get(paddingStart, paddingSize);
            LevelPlan levelPlan = ZandomLevelGenerator.GeneratorCoroutine.Level;
            foreach (var item in paddingCoordinates)
            {
                levelPlan.Tiles.TryGetValue(item, out TilePlan itemTile);
                bool checkOk = PaddingCheck(itemTile);
                if (!checkOk) return false;
            }
            foreach (var item in obstacleCoordinates)
            {
                levelPlan.Tiles.TryGetValue(item, out TilePlan itemTile);
                bool checkOk = ObstacleCheck(itemTile);
                if (!checkOk) return false;
            }
            return true;
        }

        private bool PaddingCheck(TilePlan tile)
        {
            return Parameters.PaddingTileFunction(ZandomLevelGenerator, tile);
        }

        private bool ObstacleCheck(TilePlan tile)
        {
            return Parameters.ObstacleTileFunction(ZandomLevelGenerator, tile);
        }
    }
}
