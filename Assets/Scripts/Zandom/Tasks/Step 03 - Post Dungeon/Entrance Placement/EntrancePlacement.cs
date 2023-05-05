using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntrancePlacement : ObstaclePlacement
{
    public EntrancePlacement(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override IEnumerator Run()
    {
        Room randomRoom;
        List<Tile> tiles;
        for (int i = 0; i < 1; i++)
        {
            while (true)
            {
                List<Room> rooms = LevelGenerator.Level.Rooms.Values.ToList();
                System.Random rng = new();
                int randomIndex = rng.Next(0, rooms.Count);
                randomRoom = rooms[randomIndex];
                if (randomRoom.FromSetPiece) continue;
                if (randomRoom.Type != RoomType.NORMAL) continue;
                bool gotTiles = TryGetTiles(randomRoom, out tiles);
                if (gotTiles) break;
            }
            Obstacle entrance = Run(randomRoom, tiles);
            if (LevelGenerator.taskWaitingTier > 0)
            {
                yield return new GenerateFinalObstacles(LevelGenerator).Run(entrance);
            }
        }
    }

    public Obstacle Run(Room room, List<Tile> tiles)
    {
        Level level = LevelGenerator.Level;
        Obstacle result = level.CreateObstacle("Entrance", tiles, false, room);
        level.SetStartLocation(result.CenterPosition);
        return result;
    }

    private bool TryGetTiles(Room room, out List<Tile> tiles)
    {
        tiles = new();
        Vector2Int position = room.Start;
        Vector2Int objectSize = LevelGenerator.ZandomParameters.entranceSize;
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
            foundTiles.Add(tile);
            return true;
        }
        TileMapIterator iterator = new();
        bool result = iterator.IterateAll(position, objectSize, addTile);
        tiles = new(foundTiles);
        return result;
    }
}
