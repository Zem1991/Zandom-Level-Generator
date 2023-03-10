using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTypeRandomizer : LevelGeneratorTask
{
    public WallTypeRandomizer(LevelGenerator levelGenerator) : base(levelGenerator)
    {
    }

    public override void Run()
    {
        List<Wall> enclosedList = new();
        List<Wall> parentList = new();
        List<Wall> destructibleList = new();
        List<Wall> normalList = new();
        foreach (Wall wall in LevelGenerator.Level.Walls.Values)
        {
            int distance = new RoomDistanceFinder().Find(wall.SourceRoom, wall.NeighborRoom);
            bool tooDistant = distance >= Constants.ROOM_AGE_FOR_WEAK_WALLS;
            //int ageGap = wall.GetAgeGap();
            //bool tooOld = ageGap >= Constants.ROOM_AGE_FOR_WEAK_WALLS;
            //bool differentRoot = wall.IsDifferentRoot();
            bool enclosedRoom = wall.HasEnclosedRoom();
            bool parentWall = wall.IsParentWall();

            //if (tooOld || differentRoot)
            if (tooDistant)
            {
                destructibleList.Add(wall);
            }
            else if (enclosedRoom)
            {
                enclosedList.Add(wall);
            }
            else if (parentWall)
            {
                parentList.Add(wall);
            }
            else
            {
                //if (tooOld) destructibleList.Add(wall);
                //else normalList.Add(wall);
                normalList.Add(wall);
            }

            //if (wall.IsParentWall()) parentWalls.Add(wall);
            //else if (wall.IsDifferentRoot()) differentRoots.Add(wall);
            //else others.Add(wall);
        }
        Enclosed(enclosedList);
        Parent(parentList);
        DestructibleWall(destructibleList);
        NormalWall(normalList);
    }

    public void Enclosed(List<Wall> walls)
    {
        WallTypePicker picker = new();
        foreach (Wall wall in walls)
        {
            wall.Type = picker.Enclosed();
            Run(wall);
        }
    }

    public void Parent(List<Wall> walls)
    {
        WallTypePicker picker = new();
        foreach (Wall wall in walls)
        {
            wall.Type = picker.Parent();
            Run(wall);
        }
    }

    public void DestructibleWall(List<Wall> walls)
    {
        WallTypePicker picker = new();
        foreach (Wall wall in walls)
        {
            wall.Type = picker.Destructible();
            Run(wall);
        }
    }

    public void NormalWall(List<Wall> walls)
    {
        WallTypePicker picker = new();
        foreach (Wall wall in walls)
        {
            wall.Type = picker.Normal();
            Run(wall);
        }
    }

    private void Run(Wall wall)
    {
        foreach (Tile tile in wall.Tiles)
        {
            if (tile.Type != TileTypes.DOOR) tile.Type = wall.Type;
        }
    }
}
