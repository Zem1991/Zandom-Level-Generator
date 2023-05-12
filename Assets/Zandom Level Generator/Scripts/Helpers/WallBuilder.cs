using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder
{
    public WallBuilder(LevelGenerator levelGenerator)
    {
        LevelGenerator = levelGenerator;
    }

    private LevelGenerator LevelGenerator { get; }

    public bool CanBuild(Room sourceRoom, Room neighborRoom, List<Tile> tiles)
    {
        if (sourceRoom == null) return false;
        if (neighborRoom == null) return false;
        if (tiles.Count < 2) return false;
        return true;
    }

    public Wall Build(Room sourceRoom, Room neighborRoom, List<Tile> tiles)
    {
        Wall wall = LevelGenerator.Level.CreateWall(sourceRoom, neighborRoom, tiles);
        //foreach (var item in tiles)
        //{
        //    wall.TileMap.Add(item);
        //}
        return wall;
    }
}
