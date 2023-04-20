using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CathedralLevelGeneratorStyle : LevelGeneratorStyle
{
    protected override bool Step01_PreDungeon_Execution(out string message)
    {
        message = null;
        //new StartingRoom(LevelGenerator).Run();
        new CathedralSpine(LevelGenerator).Run();
        List<Room> startingBuddingRooms = new(LevelGenerator.Level.Rooms.Values.Take(2));
        new BuddingRooms(LevelGenerator, startingBuddingRooms).Run();
        new CathedralSpecialRooms(LevelGenerator).Run();
        new WallFinder(LevelGenerator).Run();

        AreaSumChecker dungeonAreaChecker = new(LevelGenerator);
        int minimumArea = (int)(Constants.LEVEL_AREA_MAX * LevelGenerator.ZandomParameters.levelSizeMin);
        bool levelAreaMin = dungeonAreaChecker.CheckMin(minimumArea);
        message += $" | Area {dungeonAreaChecker.Area} of {minimumArea}";
        SpecialRoomSumChecker specialRoomSumChecker = new(LevelGenerator);
        int minimumSpecials = LevelGenerator.ZandomParameters.specialRoomTarget;
        bool specialRoomsMin = specialRoomSumChecker.CheckMin(minimumSpecials);
        message += $" | Special Rooms {specialRoomSumChecker.Count} of {minimumSpecials}";
        return levelAreaMin && specialRoomsMin;
    }

    protected override bool Step02_Dungeon_Execution(out string message)
    {
        message = null;
        new RoomTypeRandomizer(LevelGenerator).Run();
        new WallTypeRandomizer(LevelGenerator).Run();
        new DoorwaySpawner(LevelGenerator).Run();
        return true;
    }

    protected override bool Step03_PostDungeon_Execution(out string message)
    {
        message = null;
        new FinalRooms(LevelGenerator).Run();
        new FinalTiles(LevelGenerator).Run();
        return true;
    }
}
