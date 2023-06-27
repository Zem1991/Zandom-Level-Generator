using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Factories;

namespace ZandomLevelGenerator.Tasks.Common
{
    public class CreateCentralRoom : GeneratorTask
    {
        public CreateCentralRoom(ZandomLevelGenerator zandomLevelGenerator, Vector3Int centralRoomSize, bool vertical) : base(zandomLevelGenerator)
        {
            RoomSize = centralRoomSize;
            Vertical = vertical;
        }

        public Vector3Int RoomSize { get; }
        public bool Vertical { get; }

        public override void RunContents()
        {
            RoomPlanFactory factory = new(ZandomLevelGenerator.ZandomParameters, ZandomLevelGenerator.GeneratorCoroutine.Level);
            int roomId = factory.NextId();
            Vector3Int halfRoomSize = RoomSize / 2;
            Vector3Int start = ZandomLevelGenerator.ZandomParameters.LevelSize / 2;
            start -= halfRoomSize;
            factory.TryCreate(roomId, start, RoomSize, Vertical, null, out RoomPlan result);
        }
    }
}
