using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;

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
            while (NewObstacles.Count <= amount)
            {
                TilePlan tile = validTilesQueue.Dequeue();
                RunForTile(data, tile);
            }
        }

        private void RunForTile(ObstacleData data, TilePlan tile)
        {
            bool gotTiles = TryGetTiles(data, tile, out List<TilePlan> tiles);
            if (!gotTiles) return;
        }

        private bool TryGetTiles(ObstacleData data, TilePlan tile, out List<TilePlan> tiles)
        {
            Vector3Int start = tile.Coordinates;
            Vector3Int size = data.Size;
            Vector3Int padding = data.Padding;
            //int extraX = LevelGenerator.SeededRandom.Range(padding.x, room.Size.x - size.x - padding.x + 1);
            //int extraY = LevelGenerator.SeededRandom.Range(padding.y, room.Size.y - size.y - padding.y + 1);
            //position.x += extraX;
            //position.y += extraY;
            List<TilePlan> foundTiles = new();
            bool addTile(int col, int floor, int row)
            {
                Vector3Int coordinates = new(col, floor, row);
                bool hasTile = ZandomLevelGenerator.GeneratorCoroutine.Level.Tiles.TryGetValue(coordinates, out TilePlan tile);
                if (!hasTile) return false;
                if (!tile.Type.IsFloor()) return false;
                if (tile.HasObstacle()) return false;
                foundTiles.Add(tile);
                return true;
            }
            TileMapIterator iterator = new();
            bool result = iterator.IterateAll(start, size, addTile);
            tiles = new(foundTiles);
            return result;
        }
    }
}
