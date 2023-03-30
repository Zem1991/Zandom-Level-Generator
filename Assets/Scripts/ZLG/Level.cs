using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public Level()
    {
        TileMap = new();
        Rooms = new();
        Walls = new();
    }

    public TileMap TileMap { get; }
    public Dictionary<int, Room> Rooms { get; }
    public Dictionary<int, Wall> Walls { get; }

    public bool IsInsideBounds(Vector2Int start, Vector2Int size)
    {
        if (start.x < 0) return false;
        if (start.y < 0) return false;
        if (start.x + size.x - 1 >= Constants.LEVEL_SIZE) return false;
        if (start.y + size.y - 1 >= Constants.LEVEL_SIZE) return false;
        return true;
    }

    //public Room CreateFinalRoom(Vector2Int start, Vector2Int size, bool vertical, Room root, Room parent)
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
        Walls.Add(id, wall);
        sourceRoom.Walls.Add(wall);
        neighborRoom.Walls.Add(wall);
        return wall;
    }
}
