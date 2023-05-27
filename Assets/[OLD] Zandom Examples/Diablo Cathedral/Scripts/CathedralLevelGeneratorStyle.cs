using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Checks;
using ZandomLevelGenerator.Components;
using ZandomLevelGenerator.Task;

namespace ZandomLevelGenerator.Examples.DiabloCathedral
{
    public class CathedralLevelGeneratorStyle : ZandomStyle
    {
        public override List<LevelGeneratorTask> Step01_Tasks(LevelGenerator levelGenerator)
        {
            return new()
            {
                //new StartingRoom(levelGenerator),
                new CathedralSpine(levelGenerator),
                new BuddingRooms(levelGenerator),
                new CathedralSpecialRooms(levelGenerator),
                new WallFinder(levelGenerator),
            };
        }

        public override bool Step01_Checks(LevelGenerator levelGenerator, out string message)
        {
            message = null;
            AreaSumChecker dungeonAreaChecker = new(levelGenerator);
            int minimumArea = (int)(Constants.LEVEL_AREA_MAX * levelGenerator.ZandomParameters.levelSizeMin);
            bool levelAreaMin = dungeonAreaChecker.CheckMin(minimumArea);
            message += $" | Area {dungeonAreaChecker.Area} of {minimumArea}";
            SpecialRoomSumChecker specialRoomSumChecker = new(levelGenerator);
            int minimumSpecials = levelGenerator.ZandomParameters.specialRoomTarget;
            bool specialRoomsMin = specialRoomSumChecker.CheckMin(minimumSpecials);
            message += $" | Special Rooms {specialRoomSumChecker.Count} of {minimumSpecials}";
            return levelAreaMin && specialRoomsMin;
        }

        public override List<LevelGeneratorTask> Step02_Tasks(LevelGenerator levelGenerator)
        {
            return new()
            {
                new RoomTypeRandomizer(levelGenerator),
                new WallTypeRandomizer(levelGenerator),
                new DoorwaySpawner(levelGenerator),
            };
        }

        public override bool Step02_Checks(LevelGenerator levelGenerator, out string message)
        {
            message = null;
            return true;
        }

        public override List<LevelGeneratorTask> Step03_Tasks(LevelGenerator levelGenerator)
        {
            return new()
            {
                new EntrancePlacement(levelGenerator),
                new ExitPlacement(levelGenerator),
                new DoorPlacement(levelGenerator),
                new TreasureEncounterPlacement(levelGenerator),
                new ChallengeEncounterPlacement(levelGenerator),
                new NormalEncounterPlacement(levelGenerator),
            };
        }

        public override bool Step03_Checks(LevelGenerator levelGenerator, out string message)
        {
            message = null;
            return true;
        }
    }
}
