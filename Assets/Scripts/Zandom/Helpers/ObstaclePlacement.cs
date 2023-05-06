using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclePlacement
{
    public ObstaclePlacement(LevelGenerator levelGenerator, ZandomObstacleData obstacleData, List<Room> validRooms)
    {
        LevelGenerator = levelGenerator;
        ObstacleData = obstacleData;
        ValidRooms = validRooms.OrderBy(x => Random.value).ToList();
        Results = new();
    }

    public LevelGenerator LevelGenerator { get; }
    public ZandomObstacleData ObstacleData { get; }
    public List<Room> ValidRooms { get; }
    public List<Obstacle> Results { get; }

    public IEnumerator Run()
    {
        int validRoomIndex = 0;
        for (int i = 0; i < ObstacleData.amountDesired; i++)
        {
            validRoomIndex++;
            validRoomIndex %= ValidRooms.Count;
            Room room = ValidRooms[validRoomIndex];
            bool gotTiles = TryGetTiles(room, out List<Tile> tiles);
            if (!gotTiles)
            {
                //i--;
                continue;
            }
            Obstacle obstacle = Run(room, tiles);
            Results.Add(obstacle);
            if (LevelGenerator.taskWaitingTier > 0)
            {
                yield return new GenerateFinalObstacles(LevelGenerator).Run(obstacle);
            }
        }
    }

    private Obstacle Run(Room room, List<Tile> tiles)
    {
        Level level = LevelGenerator.Level;
        Obstacle result = level.CreateObstacle(ObstacleData, tiles, false, room);
        return result;
    }

    private bool TryGetTiles(Room room, out List<Tile> tiles)
    {
        tiles = new();
        Vector2Int position = room.Start;
        Vector2Int objectSize = ObstacleData.size;
        int extraX = Random.Range(1, room.Size.x - objectSize.x);
        int extraY = Random.Range(1, room.Size.y - objectSize.y);
        position.x += extraX;
        position.y += extraY;

        List<Tile> foundTiles = new();
        bool addTile(int col, int row)
        {
            TileMap tileMap = LevelGenerator.Level.TileMap;
            Vector2Int coordinates = new(col, row);
            Tile tile = tileMap.Get(coordinates);
            if (tile == null) return false;
            if (tile.HasObstacle()) return false;
            foundTiles.Add(tile);
            return true;
        }
        TileMapIterator iterator = new();
        bool result = iterator.IterateAll(position, objectSize, addTile);
        tiles = new(foundTiles);
        return result;
    }
}
