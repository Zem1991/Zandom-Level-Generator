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
        ValidRooms = validRooms;// validRooms.OrderBy(x => Random.value).ToList();
        ValidTiles = new();
        Results = new();

        foreach (var item in ValidRooms)
        {
            ValidTiles.AddRange(item.Tiles);
        }
        ValidTiles = ValidTiles.OrderBy(x => Random.value).ToList();
    }

    public LevelGenerator LevelGenerator { get; }
    public ZandomObstacleData ObstacleData { get; }
    public List<Room> ValidRooms { get; }
    public List<Tile> ValidTiles { get; }
    public List<Obstacle> Results { get; }

    public IEnumerator Run()
    {
        int validRoomIndex = 0;
        for (int i = 0; i < ObstacleData.amountDesired; i++)
        {
            validRoomIndex++;
            validRoomIndex %= ValidTiles.Count;
            Tile tile = ValidTiles[validRoomIndex];
            //Room room = tile.MentionedRooms[0];
            bool gotTiles = TryGetTiles(tile, out List<Tile> tiles);
            if (!gotTiles)
            {
                i--;
                continue;
            }
            //Obstacle obstacle = Run(room, tiles);
            Obstacle obstacle = Run(tiles);
            Results.Add(obstacle);
            if (LevelGenerator.taskWaitingTier > 0)
            {
                yield return new GenerateFinalObstacles(LevelGenerator).Run(obstacle);
            }
        }
    }

    private Obstacle Run(List<Tile> tiles)
    {
        Level level = LevelGenerator.Level;
        Obstacle result = level.CreateObstacle(ObstacleData, tiles, false);
        return result;
    }

    private bool TryGetTiles(Tile tile, out List<Tile> tiles)
    {
        tiles = new();
        Room room = tile.MentionedRooms[0];
        Vector2Int position = room.Start;
        Vector2Int size = ObstacleData.size;
        Vector2Int padding = ObstacleData.padding;
        int extraX = Random.Range(padding.x, room.Size.x - size.x - padding.x + 1);
        int extraY = Random.Range(padding.y, room.Size.y - size.y - padding.y + 1);
        position.x += extraX;
        position.y += extraY;

        List<Tile> foundTiles = new();
        bool addTile(int col, int row)
        {
            TileMap tileMap = LevelGenerator.Level.TileMap;
            Vector2Int coordinates = new(col, row);
            Tile tile = tileMap.Get(coordinates);
            if (tile == null) return false;
            if (!tile.Type.IsFloor()) return false;
            if (tile.HasObstacle()) return false;
            foundTiles.Add(tile);
            return true;
        }
        TileMapIterator iterator = new();
        bool result = iterator.IterateAll(position, size, addTile);
        tiles = new(foundTiles);
        return result;
    }
}
