using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Customizables;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;
using ZandomLevelGenerator.Tools.Helpers;

namespace ZandomLevelGenerator.Examples.DiabloCathedral.Tasks
{
    public class SelectImportantRooms : GeneratorTask
    {
        public SelectImportantRooms(ZandomLevelGenerator zandomLevelGenerator) : base(zandomLevelGenerator)
        {
        }

        public override void RunContents()
        {
            LevelPlan level = ZandomLevelGenerator.GeneratorCoroutine.Level;
            TileCodeReplacer tileCodeReplacer = new(level);
            foreach (var item in level.Sectors)
            {
                SectorPlan sector = item.Value;
                RoomPlan room = sector as RoomPlan;
                if (room == null) continue;
                if (room.SetPiece != null) continue;
                int wallsWithDoorways = CountWallsWithDoorways(room);
                if (wallsWithDoorways != 1) continue;
                room.Type = SectorType.IMPORTANT;
                tileCodeReplacer.ReplaceArea(sector, "Important Floor");
            }
        }

        private int CountWallsWithDoorways(RoomPlan room)
        {
            int counter = 0;
            foreach (var item in ZandomLevelGenerator.GeneratorCoroutine.Level.BorderOverlapWalls)
            {
                BorderOverlapWall wall = item.Value;
                bool sameSource = wall.SourceId == room.Id;
                bool sameOther = wall.OtherId == room.Id;
                if (!sameSource && !sameOther) continue;
                if (!wall.HasDoorway()) continue;
                counter++;
            }
            return counter;
        }
    }
}
