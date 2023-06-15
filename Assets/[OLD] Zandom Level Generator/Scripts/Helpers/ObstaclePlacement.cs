//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using ZandomLevelGenerator.BaseObjects;
//using ZandomLevelGenerator.Components;
//using ZandomLevelGenerator.Enums;
//using ZandomLevelGenerator.Task;

//namespace ZandomLevelGenerator.Helpers
//{
//    public class ObstaclePlacement
//    {
//        public ObstaclePlacement(ZandomLevelGenerator levelGenerator, ZandomObstacle obstacleData, List<Room> validRooms)
//        {
//            ZandomLevelGenerator = levelGenerator;
//            ObstacleData = obstacleData;
//            ValidRooms = validRooms;
//            ValidTiles = new();
//            Results = new();

//            foreach (var item in ValidRooms)
//            {
//                ValidTiles.AddRange(item.Tiles);
//            }
//            //ValidTiles = ValidTiles.OrderBy(x => Random.value).ToList();
//            ValidTiles = ValidTiles.OrderBy(x => ZandomLevelGenerator.SeededRandom.Next()).ToList();
//            //int rng = ZandomLevelGenerator.SeededRandom.Next();
//            //ValidTiles = ValidTiles.OrderBy(x => rng).ToList();
//        }

//        public ZandomLevelGenerator ZandomLevelGenerator { get; }
//        public ZandomObstacle ObstacleData { get; }
//        public List<Room> ValidRooms { get; }
//        public List<Tile> ValidTiles { get; }
//        public List<Obstacle> Results { get; }

//        public IEnumerator Run()
//        {
//            int validRoomIndex = 0;
//            for (int i = 0; i < ObstacleData.amountDesired; i++)
//            {
//                validRoomIndex++;
//                validRoomIndex %= ValidTiles.Count;
//                Tile tile = ValidTiles[validRoomIndex];
//                //Room room = tile.MentionedRooms[0];
//                bool gotTiles = TryGetTiles(tile, out List<Tile> tiles);
//                if (!gotTiles)
//                {
//                    i--;
//                    continue;
//                }
//                if (!ObstacleData.canPlaceWithinStartPosition)
//                {
//                    Vector3 centerPosition = new TileListPositionFinder().Find(tiles);
//                    float distanceToStart = Vector3.Distance(centerPosition, ZandomLevelGenerator.Level.StartLocation.Position);
//                    if (distanceToStart < Constants.EntranceSafetyRadius)
//                    {
//                        i--;
//                        continue;
//                    }
//                }
//                Obstacle obstacle = Run(tiles);
//                Results.Add(obstacle);
//                if (ZandomLevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
//                {
//                    yield return new GenerateFinalObstacles(ZandomLevelGenerator).Run(obstacle);
//                }
//            }
//            if (ZandomLevelGenerator.taskWaitSetting == TaskWaitSettings.PER_TASK)
//            {
//                yield return new GenerateFinalObstacles(ZandomLevelGenerator).Run();
//            }
//        }

//        private Obstacle Run(List<Tile> tiles)
//        {
//            Level level = ZandomLevelGenerator.Level;
//            Obstacle result = level.CreateObstacle(ObstacleData, tiles, false);
//            return result;
//        }

//        private bool TryGetTiles(Tile tile, out List<Tile> tiles)
//        {
//            tiles = new();
//            Room room = tile.MentionedRooms[0];
//            Vector2Int position = room.Start;
//            Vector2Int size = ObstacleData.size;
//            Vector2Int padding = ObstacleData.padding;
//            int extraX = ZandomLevelGenerator.SeededRandom.Range(padding.x, room.Size.x - size.x - padding.x + 1);
//            int extraY = ZandomLevelGenerator.SeededRandom.Range(padding.y, room.Size.y - size.y - padding.y + 1);
//            position.x += extraX;
//            position.y += extraY;

//            List<Tile> foundTiles = new();
//            bool addTile(int col, int row)
//            {
//                TileMap tileMap = ZandomLevelGenerator.Level.TileMap;
//                Vector2Int coordinates = new(col, row);
//                Tile tile = tileMap.Get(coordinates);
//                if (tile == null) return false;
//                if (!tile.Type.IsFloor()) return false;
//                if (tile.HasObstacle()) return false;
//                foundTiles.Add(tile);
//                return true;
//            }
//            TileMapIterator iterator = new();
//            bool result = iterator.IterateAll(position, size, addTile);
//            tiles = new(foundTiles);
//            return result;
//        }
//    }
//}
