using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CathedralLevelGeneratorStyle : LevelGeneratorStyle
{
    protected override void Step01_PreDungeon()
    {
        //new StartingRoom(LevelGenerator).Run();
        new CathedralSpine(LevelGenerator).Run();
        List<Room> startingBuddingRooms = new(LevelGenerator.Level.Rooms.Values.Take(2));
        new BuddingRooms(LevelGenerator, startingBuddingRooms).Run();
        new WallFinder(LevelGenerator).Run();
    }

    protected override void Step02_Dungeon()
    {
        new RoomTypeRandomizer(LevelGenerator).Run();
        new WallTypeRandomizer(LevelGenerator).Run();
        new DoorSpawner(LevelGenerator).Run();
    }

    protected override void Step03_PostDungeon()
    {
        new FinalRooms(LevelGenerator).Run();
        new FinalTiles(LevelGenerator).Run();
    }
}
