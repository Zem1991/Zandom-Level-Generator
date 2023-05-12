using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle
{
    public Obstacle(int id, ZandomObstacleData obstacleData, List<Tile> tiles, bool vertical, Level level)
    {
        Id = id;
        ZandomObstacleData = obstacleData;
        MentionedTiles = tiles;
        Vertical = vertical;
        Level = level;
        Room = tiles[0].MentionedRooms[0];
        CenterPosition = FindCenterPosition();

        foreach (var item in tiles)
        {
            item.Obstacles.Add(this);
        }
    }

    public int Id { get; }
    public ZandomObstacleData ZandomObstacleData { get; }
    public List<Tile> MentionedTiles { get; }
    public bool Vertical { get; }
    public Level Level { get; }
    public Room Room { get; }
    public Vector3 CenterPosition { get; }
    public GameObject GeneratedObstacle { get; set; }

    private Vector3 FindCenterPosition()
    {
        Vector3 result = new();
        foreach (var item in MentionedTiles)
        {
            //result += item.GeneratedTile.transform.position;
            result.x += item.Coordinates.x;
            result.z += item.Coordinates.y;
        }
        result /= MentionedTiles.Count;
        return result;
    }
}
