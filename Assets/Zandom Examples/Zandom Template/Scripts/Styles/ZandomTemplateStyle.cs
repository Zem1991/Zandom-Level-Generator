using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Tasks.Common;
using ZandomLevelGenerator.Examples.ZandomTemplate.Customizables;

namespace ZandomLevelGenerator.Examples.ZandomTemplate.Styles
{
    public class ZandomTemplateStyle : GeneratorStyle
    {
        public override bool Step01_Checks(ZandomLevelGenerator zandomLevelGenerator, out string message)
        {
            message = null;
            int sectorCount = zandomLevelGenerator.GeneratorCoroutine.Level.Sectors.Count;
            ZandomTemplateStyleParameters zandomTemplateStyleParameters = zandomLevelGenerator.ZandomParameters as ZandomTemplateStyleParameters;
            int sectorCountTarget = zandomTemplateStyleParameters.SectorCountTarget;
            bool sectorCountOk = sectorCount >= sectorCountTarget;
            if (!sectorCountOk) message = $"Sector count below target value: {sectorCount}/{sectorCountTarget}.";
            return sectorCountOk;
        }

        public override List<GeneratorTask> Step01_Tasks(ZandomLevelGenerator zandomLevelGenerator)
        {
            ZandomTemplateStyleParameters zandomTemplateStyleParameters = zandomLevelGenerator.ZandomParameters as ZandomTemplateStyleParameters;
            Vector3Int centralRoomSize = zandomTemplateStyleParameters.CentralRoomSize;
            CreateBuddingRoomsParameters parameters = new ZandomTemplateCreateBuddingRoomsParameters().CreateParameters();
            List<GeneratorTask> result = new()
            {
                new CreateCentralRoom(zandomLevelGenerator, centralRoomSize, false),
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
            CreateBorderOverlapDoorwaysParameters parameters = new ZandomTemplateCreateBorderOverlapDoorwaysParameters().CreateParameters();
            List<GeneratorTask> result = new()
            {
                new CreateBorderOverlapWalls(zandomLevelGenerator),
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
            PlaceObstaclesParameters parameters = new ZandomTemplatePlaceStartLocationWithObstacleParameters().CreateParameters();
            List<GeneratorTask> result = new()
            {
                new PlaceStartLocationWithObstacle(zandomLevelGenerator, parameters),
            };
            return result;
        }
    }
}
