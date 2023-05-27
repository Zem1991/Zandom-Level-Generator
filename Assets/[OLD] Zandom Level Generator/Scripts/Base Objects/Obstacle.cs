using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Components;
using ZandomLevelGenerator.Helpers;

namespace ZandomLevelGenerator.BaseObjects
{
    public class Obstacle
    {
        public Obstacle(int id, ZandomObstacle obstacleData, List<Tile> tiles, bool vertical, Level level)
        {
            Id = id;
            ZandomObstacleData = obstacleData;
            MentionedTiles = tiles;
            Vertical = vertical;
            Level = level;
            Room = tiles[0].MentionedRooms[0];
            CenterPosition = new TileListPositionFinder().Find(tiles);

            foreach (var item in tiles)
            {
                item.Obstacles.Add(this);
            }
        }

        public int Id { get; }
        public ZandomObstacle ZandomObstacleData { get; }
        public List<Tile> MentionedTiles { get; }
        public bool Vertical { get; }
        public Level Level { get; }
        public Room Room { get; }
        public Vector3 CenterPosition { get; }
        public GameObject GeneratedObstacle { get; set; }
    }
}
