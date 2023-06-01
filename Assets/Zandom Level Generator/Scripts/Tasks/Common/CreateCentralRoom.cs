using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Tools.Factories;

namespace ZandomLevelGenerator.Tasks.Common
{
    public class CreateCentralRoom : GeneratorTask
    {
        public CreateCentralRoom(ZandomLevelGenerator zandomLevelGenerator, Vector3Int centralRoomSize) : base(zandomLevelGenerator)
        {
            RoomSize = centralRoomSize;
        }

        public Vector3Int RoomSize { get; }

        protected override void RunContents()
        {
            RoomPlanFactory factory = new(ZandomLevelGenerator.GeneratorCoroutine.Level);
            int roomId = factory.NextId();
            Vector3Int halfSize = RoomSize / 2;
            Vector3Int start = halfSize;
            factory.Create(roomId, start, RoomSize, null);
        }
    }
}
