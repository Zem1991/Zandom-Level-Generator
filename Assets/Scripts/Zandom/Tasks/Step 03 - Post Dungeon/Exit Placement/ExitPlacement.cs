using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExitPlacement : LevelGeneratorTask
{
    public ExitPlacement(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override IEnumerator Run()
    {
        Level level = LevelGenerator.Level;
        ZandomObstacleData obstacleData = LevelGenerator.ZandomObstacles.Get("Exit");
        List<Room> validRooms = new();
        Vector3 startPosition = level.StartLocation.Position;
        foreach (var item in level.Rooms.Values)
        {
            if (item.FromSetPiece) continue;
            if (item.Type != RoomType.NORMAL) continue;
            float minDistance = Constants.EntranceSafetyRadius + Constants.ExitSafetyRadius;
            bool withinDistance = CheckWithinDistance(item.Center, startPosition, minDistance);
            if (withinDistance) continue;
            validRooms.Add(item);
        }
        ObstaclePlacement obstaclePlacement = new(LevelGenerator, obstacleData, validRooms);
        yield return obstaclePlacement.Run();
        Obstacle result = obstaclePlacement.Results[0];
        level.AddPointOfInterest(result.CenterPosition, "Exit Zone");
        if (LevelGenerator.taskWaitingTier > 0)
        {
            yield return new GenerateFinalObstacles(LevelGenerator).Run();
        }
        //Room randomRoom;
        //List<Tile> tiles;
        //for (int i = 0; i < 1; i++)
        //{
        //    while (true)
        //    {
        //        Level level = LevelGenerator.Level;
        //        List<Room> rooms = level.Rooms.Values.ToList();
        //        System.Random rng = new();
        //        int randomIndex = rng.Next(0, rooms.Count);
        //        randomRoom = rooms[randomIndex];
        //        if (randomRoom.FromSetPiece) continue;
        //        if (randomRoom.Type != RoomType.NORMAL) continue;
        //        float minDistance = Constants.EntranceSafetyRadius + Constants.ExitSafetyRadius;
        //        if (CheckWithinDistance(randomRoom.Center, LevelGenerator.Level.StartLocation.Position, minDistance)) continue;
        //        bool gotTiles = TryGetTiles(randomRoom, out tiles);
        //        if (gotTiles) break;
        //    }
        //    Obstacle entrance = Run(randomRoom, tiles);
        //    if (LevelGenerator.taskWaitingTier > 0)
        //    {
        //        yield return new GenerateFinalObstacles(LevelGenerator).Run(entrance);
        //    }
        //}
    }

    //public Obstacle Run(Room room, List<Tile> tiles)
    //{
    //    Level level = LevelGenerator.Level;
    //    Obstacle result = level.CreateObstacle("Exit", tiles, false, room);
    //    level.AddPointOfInterest(result.CenterPosition, "Exit Zone");
    //    return result;
    //}

    private bool CheckWithinDistance(Vector3 pos1, Vector3 pos2, float threshold)
    {
        float distance = Vector3.Distance(pos1, pos2);
        return distance <= threshold;
    }

    //private bool TryGetTiles(Room room, out List<Tile> tiles)
    //{
    //    tiles = new();
    //    Vector2Int position = room.Start;
    //    Vector2Int objectSize = LevelGenerator.ZandomParameters.entranceSize;
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
