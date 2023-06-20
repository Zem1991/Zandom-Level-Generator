using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Examples.DiabloCathedral.Tasks;
using ZandomLevelGenerator.Tasks.Common;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Styles
{
    public class DiabloCathedralStyle : GeneratorStyle
    {
        public override bool Step01_Checks(ZandomLevelGenerator zandomLevelGenerator, out string message)
        {
            message = null;
            return true;

            //OLD
            //int sectorCount = zandomLevelGenerator.GeneratorCoroutine.Level.Sectors.Count;
            //DiabloCathedralStyleParameters DiabloCathedralStyleParameters = zandomLevelGenerator.ZandomParameters as DiabloCathedralStyleParameters;
            //int sectorCountTarget = DiabloCathedralStyleParameters.SectorCountTarget;
            //bool sectorCountOk = sectorCount >= sectorCountTarget;
            //if (!sectorCountOk) message = $"Sector count below target value: {sectorCount}/{sectorCountTarget}.";
            //return sectorCountOk;

            //NEW
            //AreaSumChecker dungeonAreaChecker = new(zandomLevelGenerator);
            //int minimumArea = (int)(Constants.LEVEL_AREA_MAX * zandomLevelGenerator.ZandomParameters.levelSizeMin);
            //bool levelAreaMin = dungeonAreaChecker.CheckMin(minimumArea);
            //message += $" | Area {dungeonAreaChecker.Area} of {minimumArea}";
            //SpecialRoomSumChecker specialRoomSumChecker = new(zandomLevelGenerator);
            //int minimumSpecials = zandomLevelGenerator.ZandomParameters.specialRoomTarget;
            //bool specialRoomsMin = specialRoomSumChecker.CheckMin(minimumSpecials);
            //message += $" | Special Rooms {specialRoomSumChecker.Count}/{minimumSpecials}";
            //return levelAreaMin && specialRoomsMin;
        }

        public override List<GeneratorTask> Step01_Tasks(ZandomLevelGenerator zandomLevelGenerator)
        {
            CreateBuddingRoomsParameters parameters = new DiabloCathedralCreateBuddingRoomsParameters().CreateParameters();
            Vector3Int centralRoomSize = new(20, 1, 20);
            List<GeneratorTask> result = new()
            {
                new DiabloCathedralSpine(zandomLevelGenerator),
                //new CreateCentralRoom(zandomLevelGenerator, centralRoomSize, false),
                new CreateBuddingRooms(zandomLevelGenerator, parameters),
            };
            return result;
        }

        public override bool Step02_Checks(ZandomLevelGenerator zandomLevelGenerator, out string message)
        {
            message = null;
            return true;
        }

        public override List<GeneratorTask> Step02_Tasks(ZandomLevelGenerator zandomLevelGenerator)
        {
            CreateBorderOverlapDoorwaysParameters parameters = new DiabloCathedralCreateBorderOverlapDoorwaysParameters().CreateParameters();
            List<GeneratorTask> result = new()
            {
                new CreateBorderOverlapWalls(zandomLevelGenerator),
                new SelectImportantRooms(zandomLevelGenerator),
                //new WallTypeRandomizer(zandomLevelGenerator),
                new CreateBorderOverlapDoorways(zandomLevelGenerator, parameters),
            };
            return result;
        }

        public override bool Step03_Checks(ZandomLevelGenerator zandomLevelGenerator, out string message)
        {
            message = null;
            bool startLocationOk = zandomLevelGenerator.GeneratorCoroutine.Level.StartLocation != null;
            if (!startLocationOk) message = $"Start Location was not set.";
            return startLocationOk;
        }

        public override List<GeneratorTask> Step03_Tasks(ZandomLevelGenerator zandomLevelGenerator)
        {
            PlaceObstaclesParameters startLocationParameters = new DiabloCathedralPlaceStartLocationWithObstacleParameters().CreateParameters();
            PlaceDoorwayObstaclesParameters smallDoorParameters = new DiabloCathedralPlaceSmallDoorParameters().CreateParameters();
            PlaceDoorwayObstaclesParameters largeDoorParameters = new DiabloCathedralPlaceLargeDoorParameters().CreateParameters();
            List<GeneratorTask> result = new()
            {
                new PlaceStartLocationWithObstacle(zandomLevelGenerator, startLocationParameters),
                new PlaceExit(zandomLevelGenerator, startLocationParameters),
                new PlaceDoorwayObstacles(zandomLevelGenerator, smallDoorParameters),
                new PlaceDoorwayObstacles(zandomLevelGenerator, largeDoorParameters),
                new PlaceTreasureEncounter(zandomLevelGenerator),
                new PlaceChallengeEncounter(zandomLevelGenerator),
                new PlaceNormalEncounter(zandomLevelGenerator),
            };
            return result;
        }
    }
}
