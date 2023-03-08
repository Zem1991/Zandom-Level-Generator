using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wall
{
    public Wall(int id, Level level, Room sourceRoom, Room neighborRoom, List<Tile> tiles)
    {
        Id = id;
        Level = level;
        SourceRoom = sourceRoom;
        NeighborRoom = neighborRoom;
        Tiles = tiles;
        //TileMap = new();
        //Start = start;
        //Size = size;
        //Vector2Int start = tiles.First().Coordinates;
        //Vector2Int size = tiles.Last().Coordinates + Vector2Int.one - start;
    }

    public int Id { get; }
    public Level Level { get; }
    public Room SourceRoom { get; }
    public Room NeighborRoom { get; }
    public List<Tile> Tiles { get; }

    public Vector2Int Start
    {
        get
        {
            return Tiles.First().Coordinates;
        }
    }
    public Vector2Int Size
    {
        get
        {
            return Tiles.Last().Coordinates + Vector2Int.one - Start;
        }
    }
    //public TileMap TileMap { get; }

    public char Type { get; set; }

    //public void Add(Vector2Int coordinates)
    //{
    //    Tile tile = LevelGenerator.TileMap.Get(coordinates);
    //    TileMap.Add(tile);
    //}

    public int GetAgeGap()
    {
        return Mathf.Abs(SourceRoom.Age - NeighborRoom.Age);
    }

    public bool IsDifferentRoot()
    {
        bool haveSourceRoot = SourceRoom.Root != null;
        bool haveNeighborRoot = NeighborRoom.Root != null;
        bool different = SourceRoom.Root != NeighborRoom.Root;
        return haveSourceRoot && haveNeighborRoot && different;
    }

    public bool HasEnclosedRoom()
    {
        return SourceRoom.IsEnclosed() || NeighborRoom.IsEnclosed();
    }

    public bool IsParentWall()
    {
        return SourceRoom == NeighborRoom.Parent;
    }
    
    public bool CanHaveDoor()
    {
        bool validAsWall = IsDifferentRoot() || IsParentWall();
        bool validType = Type == TileTypes.WALL || Type == TileTypes.BARS;
        return validAsWall && validType;
    }
}
