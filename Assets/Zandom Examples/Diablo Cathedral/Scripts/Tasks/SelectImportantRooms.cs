using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Tasks
{
    public class SelectImportantRooms : GeneratorTask
    {
        public SelectImportantRooms(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public override void RunContents()
        {
            foreach (var item in ZandomLevelGenerator.GeneratorCoroutine.Level.Sectors)
            {
                SectorPlan sector = item.Value;
                RoomPlan room = sector as RoomPlan;
                if (room == null) continue;
                int wallCount = CountWalls(room);
                if (wallCount > 1) continue;
                room.Type = SectorType.IMPORTANT;
            }
        }

        private int CountWalls(RoomPlan room)
        {
            int counter = 0;
            foreach (var item in ZandomLevelGenerator.GeneratorCoroutine.Level.BorderOverlapWalls)
            {
                BorderOverlapWall wall = item.Value;
                bool sameSource = wall.SourceId == room.Id;
                bool sameOther = wall.OtherId == room.Id;
                if (!sameSource && !sameOther) continue;
                counter++;
            }
            return counter;
        }
    }
}
