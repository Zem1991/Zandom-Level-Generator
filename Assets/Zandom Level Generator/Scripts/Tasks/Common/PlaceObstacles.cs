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
                bool checkOk = TileCheck(item);
                if (!checkOk) continue;
                tiles.Add(item);
            }
            tiles = tiles.OrderBy(x => ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Next()).ToList();
            return tiles;
        }

        private bool TryStartTile(TilePlan startTile, ObstacleData data, out HashSet<Vector3Int> coordinates)
        {
            Vector3Int start = startTile.Coordinates;
            Vector3Int size = data.Size;
            Vector3Int padding = data.Padding;
            //int extraX = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(padding.x, room.Size.x - size.x - padding.x + 1);
            //int extraZ = ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Range(padding.z, room.Size.z - size.z - padding.z + 1);
            //position.x += extraX;
            //position.z += extraZ;
            start -= padding;
            size += padding;
            size += padding;
            coordinates = new CoordinatesGetter().Get(start, size);
            foreach (var item in coordinates)
            {
                ZandomLevelGenerator.GeneratorCoroutine.Level.Tiles.TryGetValue(item, out TilePlan itemTile);
                bool checkOk = TileCheck(itemTile);
                if (!checkOk) return false;
            }
            return true;
        }

        private bool TileCheck(TilePlan tile)
        {
            bool hasTile = tile != null;
            if (!hasTile) return false;
            bool hasObstacle = tile.HasObstacle();
            if (hasObstacle) return false;
            bool canPlaceObstacle = Parameters.ValidTileFunction(ZandomLevelGenerator, tile);
            if (!canPlaceObstacle) return false;
            return true;
        }
    }
}
