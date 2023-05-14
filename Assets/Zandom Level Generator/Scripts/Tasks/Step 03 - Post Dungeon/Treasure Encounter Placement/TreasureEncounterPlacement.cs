using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.BaseObjects;
using ZandomLevelGenerator.Components;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.Helpers;

namespace ZandomLevelGenerator.Task
{
    public class TreasureEncounterPlacement : LevelGeneratorTask
    {
        public TreasureEncounterPlacement(LevelGenerator levelGenerator) : base(levelGenerator)
        {
        }

        public override IEnumerator Run()
        {
            ZandomObstacleData obstacleData = LevelGenerator.ZandomObstacles.Get("Treasure Encounter");
            List<Room> validRooms = new();
            foreach (var item in LevelGenerator.Level.Rooms.Values)
            {
                if (item.Type != RoomType.SPECIAL) continue;
                validRooms.Add(item);
            }
            ObstaclePlacement obstaclePlacement = new(LevelGenerator, obstacleData, validRooms);
            yield return obstaclePlacement.Run();
            if (LevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
            {
                yield return new GenerateFinalObstacles(LevelGenerator).Run();
            }
            //List<Room> allRooms = LevelGenerator.Level.Rooms.Values.ToList();
            //List<Room> validRooms = new();
            //foreach (var item in allRooms)
            //{
            //    if (item.Type != RoomType.SPECIAL) continue;
            //    validRooms.Add(item);
            //}
            //validRooms = validRooms.OrderBy(x => Random.value).ToList();
            //int validRoomIndex = 0;
            //for (int i = 0; i < LevelGenerator.ZandomParameters.treasures; i++)
            //{
            //    validRoomIndex++;
            //    validRoomIndex %= validRooms.Count;
            //    Room room = validRooms[validRoomIndex];
            //    bool gotTiles = TryGetTiles(room, out List<Tile> tiles);
            //    if (!gotTiles)
            //    {
            //        i--;
            //        continue;
            //    }
            //    Obstacle treasure = Run(room, tiles);
            //    if (LevelGenerator.taskWaitSetting == TaskWaitSettings.PER_ITERATION)
            //    {
            //        yield return new GenerateFinalObstacles(LevelGenerator).Run(treasure);
            //    }
            //}
        }

        //private Obstacle Run(Room room, List<Tile> tiles)
        //{
        //    Level level = LevelGenerator.Level;
        //    Obstacle result = level.CreateObstacle("Treasure", tiles, false, room);
        //    return result;
        //}

        //private bool TryGetTiles(Room room, out List<Tile> tiles)
        //{
        //    tiles = new();
        //    Vector2Int position = room.Start;
        //    Vector2Int objectSize = LevelGenerator.ZandomParameters.treasureSize;
        //    int extraX = Random.Range(1, room.Size.x - objectSize.x);
        //    int extraY = Random.Range(1, room.Size.y - objectSize.y);
        //    position.x += extraX;
        //    position.y += extraY;

        //    List<Tile> foundTiles = new();
        //    bool addTile(int col, int row)
        //    {
        //        TileMap tileMap = LevelGenerator.Level.TileMap;
        //        Vector2Int coordinates = new(col, row);
        //        Tile tile = tileMap.Get(coordinates);
        //        if (tile == null) return false;
        //        if (tile.HasObstacle()) return false;
        //        foundTiles.Add(tile);
        //        return true;
        //    }
        //    TileMapIterator iterator = new();
        //    bool result = iterator.IterateAll(position, objectSize, addTile);
        //    tiles = new(foundTiles);
        //    return result;
        //}
    }
}
