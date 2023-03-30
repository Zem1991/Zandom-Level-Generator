using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    //public Room(int id, Vector2Int start, Vector2Int size, bool vertical, Room root, Room parent, Level level)
    public Room(int id, Level level, Vector2Int start, Vector2Int size, bool vertical, Room parent)
    {
        Id = id;
        Level = level;
        Start = start;
        Size = size;
        Vertical = vertical;
        Parent = parent;
        //TileMap = new();
        Tiles = new();
        Walls = new();
        Children = new();
        DefineRootAndAge();
    }

    public int Id { get; }
    public Level Level { get; }
    public Vector2Int Start { get; }
    public Vector2Int Size { get; }
    public bool Vertical { get; }
    //public Room Root { get; }
    public Room Parent { get; }
    //public TileMap TileMap { get; }
    public List<Tile> Tiles { get; }
    public List<Wall> Walls { get; }
    public List<Room> Children { get; }
    
    public Room Root { get; private set; }
    public int Age { get; private set; }
    public char Type { get; set; }
    public FinalRoom GeneratedRoom { get; set; }

    public int Area
    {
        get
        {
            int x = Size.x;// - Start.x + 1;
            int y = Size.y;// - Start.y + 1;
            return x + y;
        }
    }

    //public void Add(Vector2Int coordinates)
    //{
    //    Tile tile = LevelGenerator.TileMap.Get(coordinates);
    //    TileMap.Add(tile);
    //}

    //public bool HasOneDoorMaximum()
    //{
    //    return Walls.Count <= 1;
    //    //int count = 0;
    //    //foreach (Wall wall in Walls)
    //    //{
    //    //    if (wall.CanHaveDoor()) count++;
    //    //}
    //    //return count <= 1;
    //}

    public override string ToString()
    {
        return $"Room #{Id}";
    }

    public bool IsEnclosed()
    {
        bool hasParent = Parent != null;
        bool noChildren = Children.Count <= 0;
        return hasParent && noChildren;
    }

    private void DefineRootAndAge()
    {
        Root = null;
        Age = 0;
        if (Parent != null)
        {
            Root = Parent.Root ?? this;
            Age = Parent.Age + 1;
        }
    }
}
