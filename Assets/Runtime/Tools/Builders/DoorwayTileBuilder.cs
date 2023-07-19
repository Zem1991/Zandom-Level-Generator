using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZandomLevelGenerator.Enums;
using ZandomLevelGenerator.GeneratorObjects;

namespace ZandomLevelGenerator.Tools.Builders
{
    public class DoorwayTileBuilder
    {
        public DoorwayTileBuilder(BorderOverlapDoorway borderOverlapDoorway)
        {
            BorderOverlapDoorway = borderOverlapDoorway;
        }

        public BorderOverlapDoorway BorderOverlapDoorway { get; }

        public void FillDoorway()
        {
            foreach (var item in BorderOverlapDoorway.TilesIds)
            {
                BorderOverlapDoorway.LevelPlan.Tiles.TryGetValue(item, out TilePlan tile);
                tile.Overlap = TileOverlap.DOORWAY;
            }
        }
    }
}
