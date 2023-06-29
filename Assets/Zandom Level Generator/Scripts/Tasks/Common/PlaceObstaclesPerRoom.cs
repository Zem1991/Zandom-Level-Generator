using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Factories;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Tasks.Common
{
    public class PlaceObstaclesPerRoom : GeneratorTask
    {
        public PlaceObstaclesPerRoom(ZandomLevelGenerator zandomLevelGenerator, string objectName, PlaceObstaclesParameters parameters) : base(zandomLevelGenerator)
        {
            ObjectName = objectName;
            Parameters = parameters;
            NewObstacles = new();
        }

        public string ObjectName { get; }
        public PlaceObstaclesParameters Parameters { get; }
        public Dictionary<int, Obstacle> NewObstacles { get; }

        public Dictionary<SectorPlan, List<TilePlan>> SectorsAndTiles { get; private set; }
        public int RemainingTiles { get; private set; }

        public override void RunContents()
        {
            LevelPlan levelPlan = ZandomLevelGenerator.GeneratorCoroutine.Level;
            SectorsAndTiles = new SectorsWithTilesGetter().Get(levelPlan);
            SectorsAndTiles = new (SectorsAndTiles.OrderBy(x => ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Next()));
            RemainingTiles = levelPlan.Tiles.Count;
            string name = ObjectName;
            ObstacleData data = ZandomLevelGenerator.ZandomObstacleList.Get(name);
            int amount = Parameters.AmountFunction(ZandomLevelGenerator);
            int roomIndex = 0;
            while (NewObstacles.Count < amount && RemainingTiles > 0)
            {
                KeyValuePair<SectorPlan, List<TilePlan>> keyValuePair = SectorsAndTiles.ElementAt(roomIndex);
                SectorPlan sector = keyValuePair.Key;
                List<TilePlan> tiles = keyValuePair.Value;
                if (tiles.Count > 0)
                {
                    tiles = new(tiles.OrderBy(x => ZandomLevelGenerator.GeneratorCoroutine.SeededRandom.Next()));
                    TilePlan tile = tiles[0];
                    tiles.Remove(tile);
                    bool canUseTile = TryStartTile(tile, data, out HashSet<Vector3Int> coordinates);
                    if (canUseTile)
                    {
                        ObstacleFactory factory = new(ZandomLevelGenerator.ZandomParameters, ZandomLevelGenerator.GeneratorCoroutine.Level);
                        int obstacleId = factory.NextId();
                        Obstacle obstacle = factory.Create(obstacleId, coordinates, Vector3.zero, data);
                        NewObstacles.Add(obstacleId, obstacle);
                    }
                    RemainingTiles--;
                    roomIndex++;
                }
                else
                {
                    SectorsAndTiles.Remove(sector);
                }
                if (roomIndex >= SectorsAndTiles.Count)
                {
                    roomIndex = 0;
                }
            }
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
