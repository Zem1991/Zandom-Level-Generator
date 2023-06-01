using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;

namespace ZandomLevelGenerator.Tasks.Common
{
    public class CreateBuddingRooms : GeneratorTask
    {
        public CreateBuddingRooms(ZandomLevelGenerator zandomLevelGenerator, int roots, Vector3Int buddingRoomSize) : base(zandomLevelGenerator)
        {
            Roots = roots;
            RoomSize = buddingRoomSize;
        }

        public int Roots { get; }
        public Vector3Int RoomSize { get; }

        protected override void RunContents()
        {
            throw new System.NotImplementedException();
        }
    }
}
