using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Tasks.Common;
using ZandomTemplate.Customizables;

namespace ZandomTemplate.Styles
{
    public class ZandomTemplateStyle : GeneratorStyle
    {
        public override bool Step01_Checks(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator, out string message)
        {
            message = null;
            int sectorCount = zandomLevelGenerator.GeneratorCoroutine.Level.Sectors.Count;
            int sectorCountTarget = 10;
            bool result = sectorCount >= sectorCountTarget;
            if (!result) message = $"Sector count below target value: {sectorCount}/{sectorCountTarget}";
            return result;
        }

        public override List<GeneratorTask> Step01_Tasks(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator)
        {
            ZandomTemplateStyleParameters zandomTemplateStyleParameters = zandomLevelGenerator.ZandomParameters as ZandomTemplateStyleParameters;
            Vector3Int centralRoomSize = zandomTemplateStyleParameters.CentralRoomSize;
            CreateBuddingRoomsParameters parameters = new ZandomTemplateCreateBuddingRoomsParameters(zandomLevelGenerator).CreateParameters();
            List<GeneratorTask> result = new()
            {
                new CreateCentralRoom(zandomLevelGenerator, centralRoomSize),
                new CreateBuddingRooms(zandomLevelGenerator, parameters),
            };
            return result;
        }

        public override bool Step02_Checks(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator, out string message)
        {
            message = null;
            return true;
        }

        public override List<GeneratorTask> Step02_Tasks(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator)
        {
            return new();
        }

        public override bool Step03_Checks(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator, out string message)
        {
            throw new System.NotImplementedException();
        }

        public override List<GeneratorTask> Step03_Tasks(ZandomLevelGenerator.ZandomLevelGenerator zandomLevelGenerator)
        {
            List<GeneratorTask> result = new()
            {

            };
            return result;
        }
    }
}
