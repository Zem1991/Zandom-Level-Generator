using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Components;

namespace ZandomLevelGenerator.BaseObjects
{
    public class Level
    {
        public Level()
        {
            TileMap = new();
            Rooms = new();
            Walls = new();
            Obstacles = new();
            PointsOfInterest = new();
        }

        public TileMap TileMap { get; }
        public Dictionary<int, Room> Rooms { get; }
        public Dictionary<int, Wall> Walls { get; }
        public List<Obstacle> Obstacles { get; }

        public StartLocation StartLocation { get; private set; }
        public List<PointOfInterest> PointsOfInterest { get; }

        public bool IsInsideBounds(Vector2Int start, Vector2Int size)
        {
            if (start.x < 0) return false;
            if (start.y < 0) return false;
            if (start.x + size.x - 1 >= Constants.LEVEL_SIZE_MAX) return false;
            if (start.y + size.y - 1 >= Constants.LEVEL_SIZE_MAX) return false;
            return true;
        }

        public Room CreateRoom(Vector2Int start, Vector2Int size, bool vertical, Room parent)
        {
            int id = Rooms.Count;
            //Room room = new(id, start, size, vertical, root, parent, this);
            Room room = new(id, this, start, size, vertical, parent);
            if (parent != null) parent.Children.Add(room);
            Rooms.Add(id, room);
            return room;
        }

        public Wall CreateWall(Room sourceRoom, Room neighborRoom, List<Tile> tiles)
        {
            int id = Walls.Count;
            Wall wall = new(id, this, sourceRoom, neighborRoom, tiles);
            sourceRoom.Walls.Add(wall);
            neighborRoom.Walls.Add(wall);
            Walls.Add(id, wall);
            return wall;
        }

        public Obstacle CreateObstacle(ZandomObstacle obstacleData, List<Tile> tiles, bool vertical)
        {
            int id = Obstacles.Count;
            Obstacle obstacle = new(id, obstacleData, tiles, vertical, this);
            Obstacles.Add(obstacle);
            return obstacle;
        }

        public void AddPointOfInterest(Vector3 position, string name)
        {
            PointOfInterest point = new(position, name);
            PointsOfInterest.Add(point);
        }

        public void SetStartLocation(Vector3 position)
        {
            if (StartLocation != null)
            {
                Debug.LogWarning("Start Location is already defined!");
                return;
            }
            StartLocation = new(position);
        }
    }
}
